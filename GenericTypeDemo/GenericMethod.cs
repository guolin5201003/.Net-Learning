using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypeDemo
{
    public interface IAccount
    {
        string Name { get; set; }
        decimal Balance { get; set; }
    }
    public class Account : IAccount
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }

    public static class Algorithm
    {
        public static decimal AccumulateSimple(IEnumerable<Account> accounts)
        {
            decimal sum = 0;
            foreach (var account in accounts)
            {
                sum += account.Balance;
            }
            return sum;
        }
        public static decimal Accumulate<T>(IEnumerable<T> accounts)
            where T: IAccount
        {
            decimal sum = 0;
            foreach (var account in accounts)
            {
                sum += account.Balance;
            }
            return sum;
        }

        public static T2 AccumulateLambda<T1, T2>(IEnumerable<T1> accounts, Func<T1,T2,T2> action)
        {
            T2 sum = default(T2);
            foreach (var account in accounts)
            {
                sum = action(account, sum);
            }
            return sum;
        }
    }
}
