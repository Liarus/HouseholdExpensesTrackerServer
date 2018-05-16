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
    public class ExpenseTypeCommandHandler : ICommandHandlerAsync<CreateExpenseTypeCommand>,
                                             ICommandHandlerAsync<ModifyExpenseTypeCommand>,
                                             ICommandHandlerAsync<DeleteExpenseTypeCommand>
    {
        private readonly IExpenseTypeRepository _types;

        public ExpenseTypeCommandHandler(IExpenseTypeRepository types)
        {
            _types = types;
        }

        public async Task HandleAsync(CreateExpenseTypeCommand message, CancellationToken token = default(CancellationToken))
        {
            var type = ExpenseType.Create(Guid.NewGuid(), message.UserId, message.Name, message.Symbol);
            _types.Add(type);
            await _types.SaveChangesAsync(token);
        }

        public async Task HandleAsync(ModifyExpenseTypeCommand message, CancellationToken token = default(CancellationToken))
        {
            var type = await this.GetSavingType(message.ExpenseTypeId);
            type.Modify(message.Name, message.Symbol, message.Version);
            await _types.SaveChangesAsync(token);
        }

        public async Task HandleAsync(DeleteExpenseTypeCommand message, CancellationToken token = default(CancellationToken))
        {
            var type = await this.GetSavingType(message.ExpenseTypeId);
            _types.Delete(type);
            await _types.SaveChangesAsync();
        }

        protected async Task<ExpenseType> GetSavingType(int expenseTypeId, CancellationToken token = default(CancellationToken))
        {
            var type = await _types.GetByIdAsync(expenseTypeId, token);
            if (type == null)
            {
                throw new ExpenseTypeCommandException($"Expense Type {expenseTypeId} doesn't exists");
            }
            return type;
        }
    }
}
