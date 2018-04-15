using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.DomainSpecification.Object
{
    public interface IAuditableEntity<T> : IEntity<T>
    {
        DateTime CreatedDate { get; }

        string CreatedBy { get; }

        DateTime UpdatedDate { get; }

        string UpdatedBy { get; }

        byte[] RowVersion { get; }

        void CreateAuditable(DateTime createdDate, string createdBy);

        void UpdateAuditable(DateTime updatedDate, string updatedBy);
    }
}
