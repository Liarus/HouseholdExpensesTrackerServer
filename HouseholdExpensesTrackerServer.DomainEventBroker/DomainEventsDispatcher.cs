﻿using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.DomainEventBroker
{
    public class DomainEventsDispatcher : IDomainEventDispatcher
    {
        protected readonly IContainerFacade _container;
        private List<Delegate> _actions;

        public IContainerFacade Container => _container;

        public DomainEventsDispatcher(IContainerFacade container)
        {
            _container = container;
        }

        public void ClearCallbacks()
        {
           _actions = null;
        }

        public void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (_actions == null)
            {
                _actions = new List<Delegate>();
            }
           _actions.Add(callback);
        }

        public void Raise<T>(T args) where T : IDomainEvent
        {
            if (_container != null)
            {
                foreach (var handler in _container.ResolveAll<Handles<T>>())
                {
                    handler.Handle(args);
                }
            }
               
            if (_actions != null)
            {
                foreach (var action in _actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            }    
        }
    }
}