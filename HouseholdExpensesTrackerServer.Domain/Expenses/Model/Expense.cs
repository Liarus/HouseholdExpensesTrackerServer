using HouseholdExpensesTrackerServer.Domain.Expenses.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Expenses.Model
{
    public class Expense : AggregateRoot<int>
    {
        public int HouseholdId { get; protected set; }

        public int ExpenseTypeId { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public decimal Amount { get; protected set; }

        public DateTime Date { get; protected set; }

        public virtual Period Period { get; protected set; }

        public static Expense Create(Guid identity, int householdId, int expenseTypeId, string name, string description, 
            decimal amount, DateTime date, Period period) => new Expense(identity, householdId, expenseTypeId, name, description,
                amount, date, period);

        public Expense Modify(int expenseTypeId, string name, string description, decimal amount,
            DateTime date, Period period, string rowVersion)
        {
            this.ExpenseTypeId = expenseTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
            this.Period = period;
            this.RowVersion = Convert.FromBase64String(rowVersion);
            this.ApplyEvent(new ExpenseModifiedEvent(this.Identity, this.Id, expenseTypeId, name, description, amount, date,
                period.PeriodStart, period.PeriodEnd));
            return this;
        }

        protected Expense(Guid identity, int householdId, int expenseTypeId, string name, string description, decimal amount, 
            DateTime date, Period period)
        {
            this.Identity = identity;
            this.ExpenseTypeId = expenseTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
            this.Period = period;
            this.ApplyEvent(new ExpenseCreatedEvent(identity, householdId, expenseTypeId, name, description,
                amount, date, period.PeriodStart, period.PeriodEnd));
        }

        protected Expense()
        {

        }
    }
}
