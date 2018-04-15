using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.DomainSpecification.Object
{
    public abstract class AuditableEntity<T> : IAuditableEntity<T>
    {
        public T Id { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public string CreatedBy { get; private set; }

        public DateTime UpdatedDate { get; private set; }

        public string UpdatedBy { get; private set; }

        public byte[] RowVersion { get; protected set; }


        public void CreateAuditable(DateTime createdDate, string createdBy)
        {
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.UpdatedDate = createdDate;
            this.UpdatedBy = createdBy;
        }

        public void UpdateAuditable(DateTime updatedDate, string updatedBy)
        {
            this.UpdatedDate = updatedDate;
            this.UpdatedBy = updatedBy;
        }
    }
}
