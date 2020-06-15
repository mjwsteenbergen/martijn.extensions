
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martijn.Extensions.AsyncLinq
{
    public static class AsyncLinqExtensions
    {
        public async static Task<IEnumerable<T>> WhenAll<T>(this IEnumerable<Task<T>> enumerable)
        {
            return (await Task.WhenAll(enumerable));
        }

        public static Task WhenAll(this IEnumerable<Task> enumerable)
        {
            return (Task.WhenAll(enumerable));
        }

        public async static IAsyncEnumerable<T> ToIAsyncEnumberable<T>(this IEnumerable<Task<T>> enumerable)
        {
            foreach (var item in enumerable)
            {
                var res = await item;
                yield return res;
            }
        }

        public static async Task Foreach<T>(this IAsyncEnumerable<T> IEnumerable, Action<T> func)
        {
            await foreach (var item in IEnumerable)
            {
                func(item);
            }
        }

        public static async IAsyncEnumerable<V> Select<T,V>(this IAsyncEnumerable<T> enumerable, Func<T,V> func) {
            await foreach (var item in enumerable)
            {
                yield return func(item);
            }
        }
    }
}