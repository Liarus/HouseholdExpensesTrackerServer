using HouseholdExpensesTrackerServer.Domain.SharedKernel.Message;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Messages
{
    public interface IMessageHandler<in T> where T : IMessage
    {
        Task Handle(T message, CancellationToken token = default(CancellationToken));
    }
}
