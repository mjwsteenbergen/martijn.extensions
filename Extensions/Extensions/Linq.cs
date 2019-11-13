using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Martijn.Extensions.Linq
{
    public static class LinqExtensions
    {
        public static string CombineWithNewLine(this IEnumerable<string> IEnumerable)
        {
            return IEnumerable.Combine((i, j) => i + "\n" + j);
        }

        public static string CombineWithSpace(this IEnumerable<string> IEnumerable)
        {
            return IEnumerable.Combine((i, j) => i + " " + j);
        }

        public static T Combine<T>(this IEnumerable<T> IEnumerable, Func<T, T, T> func)
        {
            var count = 0;
            foreach (var item in IEnumerable)
            {
                count++;

                if (count > 2)
                {
                    break;
                }
            }

            if (count >= 2)
            {
                return IEnumerable.Aggregate(func);
            }
            else if (count == 1)
            {
                return IEnumerable.First();
            }
            else
            {
                return default(T);
            }
        }

        public static void Foreach<T>(this IEnumerable<T> IEnumerable, Action<T> func)
        {
            foreach (var item in IEnumerable)
            {
                func(item);
            }
        }
    }
}