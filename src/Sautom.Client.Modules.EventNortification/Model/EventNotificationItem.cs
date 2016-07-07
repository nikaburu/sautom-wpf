using System;

namespace Sautom.Client.Modules.EventNortification.Model
{
    public class EventNotificationItem
    {
	    public EventNotificationItem(string message, EventType type, Uri actionUri)
        {
            Id = Guid.NewGuid();

            Message = message;
            Type = type;
            ActionUri = actionUri;
        }

	    public Guid Id { get; private set; }
	    public string Message { get; private set; }
	    public EventType Type { get; private set; }
	    public Uri ActionUri { get; private set; }
    }

    public enum EventType
    {
        Information,
        Warning,
        Caution
    }
}
