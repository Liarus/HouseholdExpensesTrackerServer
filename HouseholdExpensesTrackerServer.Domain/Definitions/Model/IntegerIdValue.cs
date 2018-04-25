using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Definitions.Model
{
    public class IntegerIdValue : ValueObject, IIdValue
    {
        private readonly int _id;

        public string Id => _id.ToString();

        public static IntegerIdValue Create(int id) => new IntegerIdValue(id);

        protected IntegerIdValue(int id)
        {
            _id = id;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _id;
        }
    }
}
