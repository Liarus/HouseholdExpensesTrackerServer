﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Object
{
    public interface IEntity<TIdentifier>
    {
        TIdentifier Id { get; }
    }
}
