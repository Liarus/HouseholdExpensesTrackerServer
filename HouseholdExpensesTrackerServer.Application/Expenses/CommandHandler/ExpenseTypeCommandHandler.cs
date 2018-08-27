using HouseholdExpensesTrackerServer.Application.Expenses.Command;
using HouseholdExpensesTrackerServer.Common.Command;
using HouseholdExpensesTrackerServer.Common.Type;
using HouseholdExpensesTrackerServer.Domain.Expenses.Model;
using HouseholdExpensesTrackerServer.Domain.Expenses.Repository;
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
            var type = await this.GetSavingTypeAsync(message.ExpenseTypeId);
            type.Modify(message.Name, message.Symbol, message.Version);
            await _types.SaveChangesAsync(token);
        }

        public async Task HandleAsync(DeleteExpenseTypeCommand message, CancellationToken token = default(CancellationToken))
        {
            var type = await this.GetSavingTypeAsync(message.ExpenseTypeId);
            _types.Delete(type);
            await _types.SaveChangesAsync();
        }

        protected async Task<ExpenseType> GetSavingTypeAsync(int expenseTypeId, CancellationToken token = default(CancellationToken))
        {
            var type = await _types.GetByIdAsync(expenseTypeId, token);
            if (type == null)
            {
                throw new HouseholdException($"Expense Type {expenseTypeId} doesn't exists");
            }
            return type;
        }
    }
}
