﻿using Autofac;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Dispatchers
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IComponentContext _componentContext;
        private List<Delegate> _actions;

        public DomainEventDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void ClearCallbacks()
        {
            _actions = null;
        }

        public async Task Publish<TEvent>(TEvent @event, 
            CancellationToken cancellationToken = default(CancellationToken)) where TEvent : IDomainEvent
        {
            ICollection<IDomainEventHandler<TEvent>> handlers;
            if (_componentContext.TryResolve(out handlers))
            {
                var tasks = new List<Task>();

                foreach (var asyncHandler in handlers)
                {
                    tasks.Add(asyncHandler.Handle(@event));
                }

                await Task.WhenAll(tasks);
            }
            else
            {
                throw new HandlerNotFoundException(@event.GetType().Name, nameof(DomainEventDispatcher));
            }
        }
    }
}
