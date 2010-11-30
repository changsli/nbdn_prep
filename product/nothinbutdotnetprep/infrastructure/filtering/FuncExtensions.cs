using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class FuncExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(
            this Func<ItemToFilter, PropertyType> accessor,
            PropertyType value_to_equal)
        {
            return new AnonymousCriteria<ItemToFilter>(x => accessor(x).Equals(value_to_equal));
        }
    }
}