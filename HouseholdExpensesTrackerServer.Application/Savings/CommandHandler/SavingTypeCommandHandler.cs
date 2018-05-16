using HouseholdExpensesTrackerServer.Application.Savings.Exception;
using HouseholdExpensesTrackerServer.Domain.Households.Command;
using HouseholdExpensesTrackerServer.Domain.Savings.Command;
using HouseholdExpensesTrackerServer.Domain.Savings.Model;
using HouseholdExpensesTrackerServer.Domain.Savings.Repository;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Application.Expenses.CommandHandler
{
    public class SavingTypeCommandHandler : ICommandHandlerAsync<CreateSavingTypeCommand>,
                                            ICommandHandlerAsync<ModifySavingTypeCommand>,
                                            ICommandHandlerAsync<DeleteSavingTypeCommand>
    {
        private readonly ISavingTypeRepository _types;

        public SavingTypeCommandHandler(ISavingTypeRepository types)
        {
            _types = types;
        }

        public async Task HandleAsync(CreateSavingTypeCommand message, CancellationToken token = default(CancellationToken))
        {
            var type = SavingType.Create(Guid.NewGuid(), message.UserId, message.Name, message.Symbol);
            _types.Add(type);
            await _types.SaveChangesAsync(token);
        }

        public async Task HandleAsync(ModifySavingTypeCommand message, CancellationToken token = default(CancellationToken))
        {
            var type = await this.GetSavingType(message.SavingTypeId);
            type.Modify(message.Name, message.Symbol, message.Version);
            await _types.SaveChangesAsync(token);
        }

        public async Task HandleAsync(DeleteSavingTypeCommand message, CancellationToken token = default(CancellationToken))
        {
            var type = await this.GetSavingType(message.SavingTypeId);
            _types.Delete(type);
            await _types.SaveChangesAsync();
        }

        protected async Task<SavingType> GetSavingType(int savingTypeId, CancellationToken token = default(CancellationToken))
        {
            var type = await _types.GetByIdAsync(savingTypeId, token);
            if (type == null)
            {
                throw new SavingTypeCommandException($"Saving Type {savingTypeId} doesn't exists");
            }
            return type;
        }
    }
}
