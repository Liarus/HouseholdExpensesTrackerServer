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

        public static Permission Create(string name, string code) 
            => new Permission(name, code);

        public Permission Modify(string name, string code)
        {
            this.Name = name;
            this.Code = code;
            return this;
        }

        protected Permission(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }

        protected Permission()
        {

        }
    }
}
