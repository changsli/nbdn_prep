using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class CriteriaExtensions
    {
        public static Criteria<T> as_criteria<T>(this Predicate<T> condition)
        {
            return new AnonymousCriteria<T>(condition);
        }

        public static Criteria<T> not<T>(this Criteria<T> to_negate)
        {
            return new NotCriteria<T>(to_negate);
        }

        public static Criteria<T> and<T>(this Criteria<T> left, Criteria<T> right)
        {
            return new AndCriteria<T>(left, right);
        }

        public static Criteria<T> or<T>(this Criteria<T> left, Criteria<T> right)

        {
            return new OrCriteria<T>(left, right);
        }
    }
}