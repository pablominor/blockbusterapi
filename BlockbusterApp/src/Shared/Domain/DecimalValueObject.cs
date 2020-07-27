using System.Collections.Generic;

namespace BlockbusterApp.src.Shared.Domain
{
    public abstract class DecimalValueObject : ValueObject
    {
        private decimal value;

        public DecimalValueObject(decimal value)
        {
            this.value = value;
        }

        public decimal GetValue()
        {
            return this.value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.value;
        }
    }
}
