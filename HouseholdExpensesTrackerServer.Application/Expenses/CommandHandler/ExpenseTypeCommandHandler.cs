﻿using HouseholdExpensesTrackerServer.Application.Expenses.Exception;
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
    public class ExpenseTypeCommandHandler : ICommandHandler<CreateExpenseTypeCommand>,
                                             ICommandHandler<ModifyExpenseTypeCommand>
    {
        private readonly IExpenseTypeRepository _types;

        public ExpenseTypeCommandHandler(IExpenseTypeRepository types)
        {
            _types = types;
        }

        public async Task Handle(CreateExpenseTypeCommand message, CancellationToken token = default(CancellationToken))
        {
            var type = ExpenseType.Create(Guid.NewGuid(), message.UserId, message.Name, message.Symbol);
            _types.Add(type);
            await _types.SaveChangesAsync(token);
        }

        public async Task Handle(ModifyExpenseTypeCommand message, CancellationToken token = default(CancellationToken))
        {
            var type = await _types.GetByIdAsync(message.ExpenseTypeId);
            if (type == null)
            {
                throw new ExpenseTypeCommandException($"Expense Type {message.ExpenseTypeId} doesn't exists");
            }
            type.Modify(message.Name, message.Symbol, message.RowVersion);
            await _types.SaveChangesAsync(token);
        }
    }
}
