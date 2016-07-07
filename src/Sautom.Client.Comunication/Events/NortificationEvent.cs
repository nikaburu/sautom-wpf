using System;
using Prism.Events;

namespace Sautom.Client.Comunication.Events
{
    public sealed class NortificationEvent : PubSubEvent<Nortification>
    {
    }

    public sealed class Nortification
    {
        public Nortification()
        {
            NortificationId = Guid.NewGuid();
        }

        public Guid NortificationId { get; set; }

        public string NortificationText { get; set; }
        public NortificationType NortificationType { get; set; }
        public int CloseAfter { get; set; }
    }
}
