using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypeDemo
{
    public class Nullable<T> where T : struct
    {
        private bool hasValue;
        public bool HasValue => hasValue;


        private T value;
        public T Value => value;

        public Nullable(T value)
        {
            this.hasValue = true;
            this.value = value;
        }

        public static explicit operator T(Nullable<T> value)
        {
            return value.Value;
        }

        public static implicit operator Nullable<T>(T value)
        {
            return new Nullable<T>(value);
        }

        public override string ToString()
        {
            if (!HasValue)
                return String.Empty;
            return this.value.ToString();
        }
    }
}
