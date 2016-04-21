using DDDWebApiAngularJS.DomainLayer.SharedKernel.Event;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Handler.Contract;
using System.Collections.Generic;

namespace DDDWebApiAngularJS.DomainLayer.SharedKernel.Handler
{
    public class DomainNotificationHandler : IHandler<DomainNotification>
    {
        private List<DomainNotification> notifications;

        public DomainNotificationHandler()
        {
            notifications = new List<DomainNotification>();
        }

        public void Handle(DomainNotification args)
        {
            notifications.Add(args);
        }

        public IEnumerable<DomainNotification> Notify()
        {
            return GetValue();
        }

        private List<DomainNotification> GetValue()
        {
            return notifications;
        }

        public bool HasNotifications()
        {
            return GetValue().Count > 0;
        }

        public void Dispose()
        {
            notifications = new List<DomainNotification>();
        }
    }
}
