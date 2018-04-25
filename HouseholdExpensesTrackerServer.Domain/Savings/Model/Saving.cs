using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Model
{
    public class Saving : AggregateRoot
    {
        public int HouseholdId { get; protected set; }

        public int SavingTypeId { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public decimal Amount { get; protected set; }

        public DateTime Date { get; protected set; }

        public static Saving Create(int savingTypeId, string name, string description,
            decimal amount, DateTime date) => new Saving(savingTypeId, name, description,
                amount, date);

        public Saving Modify(int savingTypeId, string name, string description,
            decimal amount, DateTime date)
        {
            this.SavingTypeId = savingTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
            return this;
        }

        protected Saving(int savingTypeId, string name, string description, decimal amount, DateTime date)
        {
            this.SavingTypeId = savingTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
        }

        protected Saving()
        {

        } 
    }
}
