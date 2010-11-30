using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class AnonymousCriteria<T> :Criteria<T>
    {
        Predicate<T> condition;

        public AnonymousCriteria(Predicate<T> condition)
        {
            this.condition = condition;
        }

        public bool matches(T item)
        {
            return condition(item);
        }
    }
}