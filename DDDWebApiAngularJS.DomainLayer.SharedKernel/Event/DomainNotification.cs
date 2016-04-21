using DDDWebApiAngularJS.DomainLayer.SharedKernel.Event.Contract;
using System;

namespace DDDWebApiAngularJS.DomainLayer.SharedKernel.Event
{
    public class DomainNotification : IDomainEvent
    {
        public string Key { get; private set; }

        public string Value { get; private set; }

        public DateTime DateOccurred { get; private set; }

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
            DateOccurred = DateTime.Now;
        }
    }
}
