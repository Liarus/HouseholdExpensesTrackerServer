using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Savings.Command
{
    public class CreateSavingTypeCommand : BaseCommand
    {
        public readonly int UserId;

        public readonly string Name;

        public readonly string Symbol;

        public CreateSavingTypeCommand(int userId, string name, string symbol)
        {
            this.UserId = userId;
            this.Name = name;
            this.Symbol = symbol;
        }
    }
}
