using System;

namespace DDDWebApiAngularJS.DomainLayer.SharedKernel.Event.Contract
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}
