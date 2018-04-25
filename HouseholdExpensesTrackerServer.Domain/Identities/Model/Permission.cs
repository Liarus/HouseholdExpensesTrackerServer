using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Model
{
    public class Permission : AggregateRoot
    { 
        public string Code { get; protected set; }

        public string Name { get; protected set; }

        public static Permission Create(Guid aggregateId, string name, string code) 
            => new Permission(aggregateId, name, code);

        public Permission Modify(string name, string code)
        {
            this.Name = name;
            this.Code = code;
            return this;
        }

        protected Permission(Guid aggregateId, string name, string code)
        {
            this.AggregateId = aggregateId;
            this.Name = name;
            this.Code = code;
        }

        protected Permission()
        {

        }
    }
}
