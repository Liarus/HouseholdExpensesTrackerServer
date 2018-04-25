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

        public static Expense Create(int expenseTypeId, string name, string description, decimal amount,
            DateTime date, Period period) => new Expense(expenseTypeId, name, description,
                amount, date, period);

        public Expense Modify(int expenseTypeId, string name, string description, decimal amount,
            DateTime date, Period period)
        {
            this.ExpenseTypeId = expenseTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
            this.Period = period;
            return this;
        }

        protected Expense(int expenseTypeId, string name, string description, decimal amount, 
            DateTime date, Period period)
        {
            this.ExpenseTypeId = expenseTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
            this.Period = period;
        }

        protected Expense()
        {

        }
    }
}
