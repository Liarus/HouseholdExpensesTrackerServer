using Autofac;
using HouseholdExpensesTrackerServer.Common.Event;
using HouseholdExpensesTrackerServer.Common.Type;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Infrastructure.Dispatchers
{
    public class EventDispatcher : IEventDispatcherAsync
    {
        private readonly IComponentContext _componentContext;
        private List<Delegate> _actions;

        public EventDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void ClearCallbacks()
        {
            _actions = null;
        }

        public async Task PublishAsync<TEvent>(TEvent @event,
            CancellationToken cancellationToken = default(CancellationToken)) where TEvent : IEvent
        {
            if (_componentContext.TryResolve(out ICollection<IEventHandlerAsync<TEvent>> handlers))
            {
                var tasks = new List<Task>();

                foreach (var asyncHandler in handlers)
                {
                    tasks.Add(asyncHandler.HandleAsync(@event, cancellationToken));
                }

                await Task.WhenAll(tasks);
            }
            else
            {
                throw new HouseholdException(
                    $"Hanlder for event: {@event.GetType().Name} in dispatcher {nameof(EventDispatcher)} has not been found");
            }
        }
    }
}
