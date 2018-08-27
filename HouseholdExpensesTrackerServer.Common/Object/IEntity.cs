using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Common.Object
{
    public interface IEntity<TIdentity>
    {
        TIdentity Id { get; }
    }
}
