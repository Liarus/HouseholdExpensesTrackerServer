using HouseholdExpensesTrackerServer.Application.Households.Command;
using HouseholdExpensesTrackerServer.Common.Command;
using HouseholdExpensesTrackerServer.Common.Type;
using HouseholdExpensesTrackerServer.Domain.Households.Model;
using HouseholdExpensesTrackerServer.Domain.Households.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Application.Households.CommandHandler
{
    public class HouseholdCommandHandler : ICommandHandlerAsync<CreateHouseholdCommand>,
                                           ICommandHandlerAsync<ModifyHouseholdCommand>,
                                           ICommandHandlerAsync<DeleteHouseholdCommand>
    {
        private readonly IHouseholdRepository _households;
        public HouseholdCommandHandler(IHouseholdRepository households)
        {
            _households = households;
        }

        public async Task HandleAsync(CreateHouseholdCommand message, CancellationToken token = default(CancellationToken))
        {
            var household = Household.Create(Guid.NewGuid(), message.UserId, message.Name, message.Symbol,
                message.Description, Address.Create(message.Country, message.ZipCode, message.City, message.Street));
            _households.Add(household);
            await _households.SaveChangesAsync(token);
        }

        public async Task HandleAsync(ModifyHouseholdCommand message, CancellationToken token = default(CancellationToken))
        {
            var household = await this.GetHouseholdAsync(message.HouseholdId, token);
            household.Modify(message.Name, message.Symbol, message.Description,
                Address.Create(message.Country, message.ZipCode, message.City, message.Street),
                message.Version);
            await _households.SaveChangesAsync(token);
        }

        public async Task HandleAsync(DeleteHouseholdCommand message, CancellationToken token = default(CancellationToken))
        {
            var household = await this.GetHouseholdAsync(message.HouseholdId);
            household.Delete();
            _households.Delete(household);
            await _households.SaveChangesAsync(token);
        }

        protected async Task<Household> GetHouseholdAsync(int householdId, CancellationToken token = default(CancellationToken))
        {
            var household = await _households.GetByIdAsync(householdId, token);
            if (household == null)
            {
                throw new HouseholdException($"Household {householdId} doesn't exists");
            }
            return household;
        }
    }
}
