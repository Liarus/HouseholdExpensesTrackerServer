using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Object
{
    public interface IAuditableEntity
    {
        byte[] RowVersion { get; }

        void CreateAuditable(DateTime createdDate, string createdBy);

        void UpdateAuditable(DateTime updatedDate, string updatedBy);
    }
}
