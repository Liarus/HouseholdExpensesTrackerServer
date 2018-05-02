using HouseholdExpensesTrackerServer.Application.Expenses.Exception;
using HouseholdExpensesTrackerServer.Domain.Expenses.Command;
using HouseholdExpensesTrackerServer.Domain.Expenses.Model;
using HouseholdExpensesTrackerServer.Domain.Expenses.Repository;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Application.Expenses.CommandHandler
{
    public class ExpenseCommandHandler : ICommandHandlerAsync<CreateExpenseCommand>,
                                         ICommandHandlerAsync<ModifyExpenseCommand>
    {
        private readonly IExpenseRepository _expenses;

        public ExpenseCommandHandler(IExpenseRepository expenses)
        {
            _expenses = expenses;
        }

        public async Task HandleAsync(CreateExpenseCommand message, CancellationToken token = default(CancellationToken))
        {
            var expense = Expense.Create(Guid.NewGuid(), message.HouseholdId, message.ExpenseTypeId, message.Name,
                message.Description, message.Amount, message.Date, Period.Create(message.PeriodStart, message.PeriodEnd));
            _expenses.Add(expense);
            await _expenses.SaveChangesAsync(token);
        }

        public async Task HandleAsync(ModifyExpenseCommand message, CancellationToken token = default(CancellationToken))
        {
            var expense = await _expenses.GetByIdAsync(message.ExpenseId);
            if (expense == null)
            {
                throw new ExpenseCommandException($"Expense {message.ExpenseId} doesn't exists");
            }
            expense.Modify(message.ExpenseId, message.Name,message.Description, message.Amount, 
                message.Date, Period.Create(message.PeriodStart, message.PeriodEnd), message.Version);
            await _expenses.SaveChangesAsync(token);
        }
    }
}
