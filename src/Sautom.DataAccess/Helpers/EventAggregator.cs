using System;
using System.Collections.Generic;
using System.Linq;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.DataAccess.Helpers
{
    internal class EventAggregator
    {
	    private static readonly IEnumerable<Func<DatabaseContext, IEnumerable<EventNortification>>>
            Events = new Func<DatabaseContext, IEnumerable<EventNortification>>[]
                          {
                              AirlineTicketBookingExpire
                          };

	    public static ICollection<EventNortification> CheckEvents(DatabaseContext databaseContext)
        {
            List<EventNortification> nortifications = new List<EventNortification>();

            foreach (Func<DatabaseContext, IEnumerable<EventNortification>> @event in Events)
            {
                nortifications.AddRange(@event(databaseContext));
            }

            return nortifications;
        }

	    #region EventFinders

	    private static IEnumerable<EventNortification> AirlineTicketBookingExpire(DatabaseContext databaseContext)
        {
            DateTime criticalDate = DateTime.Now.Date.AddDays(2);
            return databaseContext.AirlineTickets.Where(rec => rec.BookingExpireDate <= criticalDate).ToList()
                .Select(rec => new { clietnId = rec.Order.Client.Id, clientName = rec.Order.Client.FullName, rec.BookingExpireDate }).ToArray()
                .Select(rec => new EventNortification
                {
                                       EventName = "AirlineTicketBookingExpire",
                                       Args = new Dictionary<string, object>
                                       {
                                                      {"ClientId", rec.clietnId},
                                                      {"ClientName", rec.clientName},
                                                      {"ExpireDate", rec.BookingExpireDate}
                                                  }

                                   });
        }

	    #endregion
    }
}
