using HouseholdExpensesTrackerServer.Domain.Savings.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Model
{
    public class Saving : AggregateRoot<int>
    {
        public int HouseholdId { get; protected set; }

        public int SavingTypeId { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public decimal Amount { get; protected set; }

        public DateTime Date { get; protected set; }

        public static Saving Create(Guid identity, int householdId, int savingTypeId, string name, string description,
            decimal amount, DateTime date) => new Saving(identity, householdId, savingTypeId, name, description,
                amount, date);

        public Saving Modify(int savingTypeId, string name, string description,
            decimal amount, DateTime date, string rowVersion)
        {
            this.SavingTypeId = savingTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
            this.RowVersion = Convert.FromBase64String(rowVersion);
            this.ApplyEvent(new SavingModifiedEvent(this.Identity, this.Id, savingTypeId, name, description,
                amount, date));
            return this;
        }

        protected Saving(Guid identity, int householdId, int savingTypeId, string name, string description, 
            decimal amount, DateTime date)
        {
            this.Identity = identity;
            this.HouseholdId = householdId;
            this.SavingTypeId = savingTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
            this.ApplyEvent(new SavingCreatedEvent(identity, householdId, savingTypeId, name, description,
                amount, date));
        }

        protected Saving()
        {

        } 
    }
}
