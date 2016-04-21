using System;

namespace DDDWebApiAngularJS.DomainLayer.SharedKernel.Model.Contract
{
    public interface IModel
    {
        Guid Id { get; }

        bool IsValid();
    }
}
