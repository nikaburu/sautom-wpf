using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Regions;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.CommonService;
using Sautom.Client.Modules.EventNortification.Model;
using Sautom.Client.Modules.EventNortification.Properties;

namespace Sautom.Client.Modules.EventNortification.Helpers
{
    internal class EventNotificationFormatter
    {
	    private static readonly Dictionary<string, Func<EventNortificationOutput, EventNotificationItem>> Formatters
            = new Dictionary<string, Func<EventNortificationOutput, EventNotificationItem>>
            {
                      {"AirlineTicketBookingExpire", AirlineTicketBookingExpireFormatter}
                  };

	    public static IEnumerable<EventNotificationItem> Process(IEnumerable<EventNortificationOutput> input)
        {
            return input.Select(notif => Formatters[notif.EventName](notif)).ToList();
        }

	    #region Formatters

	    private static EventNotificationItem AirlineTicketBookingExpireFormatter(EventNortificationOutput @event)
        {
            var uriQuery = new NavigationParameters
							   {
                                   {"clientId", @event.Args["ClientId"].ToString()}
                               };
            Uri uri = new Uri(PathProvider.ClientDetails + uriQuery, UriKind.Relative);
            
            string msg = string.Format(Resources.Message_AirlineTicketBookingExpire,
                                       @event.Args["ClientName"], ((DateTime)@event.Args["ExpireDate"]).ToString("d"));
            
            return new EventNotificationItem(msg, EventType.Warning, uri);
        }

	    #endregion
    }
}
