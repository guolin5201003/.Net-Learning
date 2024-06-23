using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Application.Extension
{
    public static class DecimalExtension
    {
        public static string ToStringWithoutTrailingZero(this decimal? value) 
        { 
            if (value == null)
            {
                return string.Empty;
            }
            var result = value?.ToString("G");

            if (result.Contains("."))
            {
                result = result.TrimEnd('0').TrimEnd('.');
            }

            return result;
        }

        public static string ToStringWithoutTrailingZero(this decimal value)
        {
            var result = value.ToString("G");

            if (result.Contains("."))
            {
                result = result.TrimEnd('0').TrimEnd('.');
            }

            return result;
        }

    }
}
