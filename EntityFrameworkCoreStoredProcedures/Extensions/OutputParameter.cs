using System;

namespace StoredProcedureEntityFrameworkCore1.Extensions
{
    public class OutputParameter<TValue>
    {
        private bool _hasOperationFinished = false;

        public TValue _value;
        public TValue Value
        {
            get
            {
                if (!_hasOperationFinished)
                    throw new InvalidOperationException("Operation has not finished.");

                return _value;
            }
        }

        internal void SetValueInternal(object value)
        {
            _hasOperationFinished = true;
            _value = (TValue)value;
        }
    }
}