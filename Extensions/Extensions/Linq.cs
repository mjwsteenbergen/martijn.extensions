using System;
using System.Collections.Generic;
using System.Linq;

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

        public static string Combine(this IEnumerable<string> IEnumerable, string between)
        {
            return IEnumerable.Combine((i, j) => i + between + j);
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

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> IEnumerable, Func<T, T, bool> equals, Func<T, int> hash)
        {
            return IEnumerable.Distinct(new Comparerr<T>(equals, hash));
        }

        public class Comparerr<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> equals;
            private readonly Func<T, int> hash;

            public Comparerr(Func<T, T, bool> equals, Func<T, int> hash)
            {
                this.equals = equals;
                this.hash = hash;
            }

            public bool Equals(T x, T y)
            {
                return equals(x, y);
            }

            public int GetHashCode(T obj)
            {
                return hash(obj);
            }
        }
    }
}