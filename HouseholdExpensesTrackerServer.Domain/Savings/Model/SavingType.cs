﻿using HouseholdExpensesTrackerServer.Domain.Savings.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Model
{
    public class SavingType : AggregateRoot<int>
    {
        public int UserId { get; protected set; }

        public string Name { get; protected set; }

        public string Symbol { get; protected set; }

        public static SavingType Create(Guid identity, int userId, string name, string symbol)
            => new SavingType(identity, userId, name, symbol);

        public SavingType Modify(string name, string symbol, string rowVersion)
        {
            this.Name = name;
            this.Symbol = symbol;
            this.RowVersion = Convert.FromBase64String(rowVersion);
            this.ApplyEvent(new SavingTypeModifiedEvent(this.Identity, this.Id, name, symbol));
            return this;
        }

        protected SavingType(Guid identity, int userId, string name, string symbol)
        {
            this.Identity = identity;
            this.UserId = userId;
            this.Name = name;
            this.Symbol = symbol;
            this.ApplyEvent(new SavingTypeCreatedEvent(identity, userId, name, symbol));
        }

        protected SavingType()
        {

        }
    }
}
