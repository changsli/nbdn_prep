using System;
using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure.ranges
{
    public static class RangeExtensions
    {
        public static Range<T> up_to_and_including<T>(this T start, T end) where T : IComparable<T>
        {
            return new InclusiveRange<T>(start, end);
        }

        public static Criteria<T> as_criteria<T>(this Range<T> range) where T : IComparable<T>
        {
            return new FallsInRange<T>(range);
        }
    }
}