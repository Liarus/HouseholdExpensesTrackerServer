﻿using HouseholdExpensesTrackerServer.Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Common.Event
{
    public interface IEventHandler<in T> : IMessageHandler<T> where T: IEvent
    {
    }
}
