using DDDWebApiAngularJS.DomainLayer.SharedKernel.Container.Contract;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Event.Contract;
using DDDWebApiAngularJS.DomainLayer.SharedKernel.Handler.Contract;

namespace DDDWebApiAngularJS.DomainLayer.SharedKernel.Event
{
    public static class DomainEvent
    {
        public static IContainer Container { get; set; }

        public static void Raise<TEntity>(TEntity args) where TEntity : IDomainEvent
        {
            try
            {
                if (Container != null)
                {
                    var obj = Container.GetService(typeof(IHandler<TEntity>));
                    ((IHandler<TEntity>)obj).Handle(args);
                }
            }
            catch
            {
                //throw;
            }
        }
    }
}
