using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_Practices.Utils
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<TResult> Batch<T, TResult>(this IEnumerable<T> collection, int batchSize, Func<IEnumerable<T>, TResult> resultSelector)
    {
      T[] result = null;
      var count = 0;

      foreach (var item in collection)
      {
        if (result == null)
        {
          result = new T[batchSize];
        }
        result[count++] = item;
        if (count != batchSize) continue;

        yield return resultSelector(result.Select(x => x));

        result = null;
        count = 0;
      }

      if (result != null && count > 0) yield return resultSelector(result.Take(count));
    }
  }
}