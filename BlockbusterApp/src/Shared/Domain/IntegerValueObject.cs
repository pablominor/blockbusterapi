using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Domain
{
    public abstract class IntegerValueObject : ValueObject
    {
        private int value;

        public IntegerValueObject(int value)
        {
            this.value = value;
        }

        public int GetValue()
        {
            return this.value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.value;
        }
    }
}
