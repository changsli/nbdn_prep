using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,
                                                           Predicate<T> condition)
        {
            foreach (var item in items)
            {
                if (condition(item)) yield return item;
            }            
        }

        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }
    }
}