using HouseholdExpensesTrackerServer.Domain.Identities.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Model
{
    public class Permission : AggregateRoot<int>
    { 
        public string Code { get; protected set; }

        public string Name { get; protected set; }

        public static Permission Create(Guid identity, string name, string code) 
            => new Permission(identity, name, code);

        public Permission Modify(string name, string code, string rowVersion)
        {
            this.Name = name;
            this.Code = code;
            this.RowVersion = Convert.FromBase64String(rowVersion);
            this.ApplyEvent(new PermissionModifiedEvent(this.Identity,
               this.Id, code, name));
            return this;
        }

        protected Permission(Guid identity, string name, string code)
        {
            this.Identity = identity;
            this.Name = name;
            this.Code = code;
            this.ApplyEvent(new PermissionCreatedEvent(identity, code, name));
        }

        protected Permission()
        {

        }
    }
}
