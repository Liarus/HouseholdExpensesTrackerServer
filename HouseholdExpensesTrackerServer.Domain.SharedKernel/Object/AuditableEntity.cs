using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Object
{
    public abstract class AuditableEntity : IAuditableEntity, IEntity
    {
        public int Id { get; protected set; }

        public byte[] RowVersion { get; protected set; }

        protected DateTime _createdDate;

        protected string _createdBy;

        protected DateTime? _updatedDate;

        protected string _updatedBy;

        public void CreateAuditable(DateTime createdDate, string createdBy)
        {
            _createdDate = createdDate;
            _createdBy = createdBy;
            _createdDate = createdDate;
            _createdBy = createdBy;
        }

        public void UpdateAuditable(DateTime updatedDate, string updatedBy)
        {
            _updatedDate = updatedDate;
            _updatedBy = updatedBy;
        }
    }
}
