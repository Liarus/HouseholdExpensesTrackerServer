﻿using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Expenses.Command
{
    public class ModifyExpenseCommand : BaseCommand
    {
        public readonly int ExpenseId;

        public readonly int ExpenseTypeId;

        public readonly string Name;

        public readonly string Description;

        public readonly decimal Amount;

        public readonly DateTime Date;

        public readonly DateTime PeriodStart;

        public readonly DateTime PeriodEnd;

        public readonly string RowVersion;

        public ModifyExpenseCommand(int expenseId, int expenseTypeId, string name, string description,
            decimal amount, DateTime date, DateTime periodStart, DateTime periodEnd, string rowVersion)
        {
            this.ExpenseId = expenseId;
            this.ExpenseTypeId = expenseTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
            this.PeriodStart = periodStart;
            this.PeriodEnd = periodEnd;
            this.RowVersion = rowVersion;
        }
    }
}
