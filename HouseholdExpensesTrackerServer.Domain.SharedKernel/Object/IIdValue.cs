﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Object
{
    public interface IIdValue : IValueObject
    {
        string Id { get; }
    }
}
