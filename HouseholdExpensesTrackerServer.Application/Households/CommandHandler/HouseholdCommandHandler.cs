using HouseholdExpensesTrackerServer.Application.Households.Exception;
using HouseholdExpensesTrackerServer.Application.Identities.Exception;
using HouseholdExpensesTrackerServer.Domain.Households.Command;
using HouseholdExpensesTrackerServer.Domain.Households.Model;
using HouseholdExpensesTrackerServer.Domain.Households.Repository;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Application.Households.CommandHandler
{
    public class HouseholdCommandHandler : ICommandHandler<CreateHouseholdCommand>,
                                           ICommandHandler<ModifyHouseholdCommand>
    {
        private readonly IHouseholdRepository _households;
        public HouseholdCommandHandler(IHouseholdRepository households)
        {
            _households = households;
        }

        public async Task Handle(CreateHouseholdCommand message, CancellationToken token = default(CancellationToken))
        {
            var household = Household.Create(Guid.NewGuid(), message.UserId, message.Name, message.Symbol,
                message.Description, Address.Create(message.Country, message.ZipCode, message.City, message.Street));
            _households.Add(household);
            await _households.SaveChangesAsync(token);
        }

        public async Task Handle(ModifyHouseholdCommand message, CancellationToken token = default(CancellationToken))
        {
            var household = await _households.GetByIdAsync(message.HouseholdId);
            if (household == null)
            {
                throw new HouseholdCommandException($"Household {message.HouseholdId} doesn't exists");
            }
            household.Modify(message.Name, message.Symbol, message.Description,
                Address.Create(message.Country, message.ZipCode, message.City, message.Street),
                message.RowVersion);
            await _households.SaveChangesAsync(token);
        }
    }
}
