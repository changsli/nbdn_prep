using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter,PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;
        CriteriaFactory<ItemToFilter, PropertyType> criteria_factory;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor,
                                         CriteriaFactory<ItemToFilter, PropertyType> criteria_factory)
        {
            this.property_accessor = property_accessor;
            this.criteria_factory = criteria_factory;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(x => property_accessor(x).CompareTo(value) > 0);
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return criteria_factory.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] properties)
        {
            return criteria_factory.equal_to_any(properties);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return criteria_factory.not_equal_to(value);
        }

        public Criteria<ItemToFilter> between(PropertyType start,PropertyType end)
        {
            return new AnonymousCriteria<ItemToFilter>(x => property_accessor(x).CompareTo(start) >= 0 &&
                property_accessor(x).CompareTo(end) <= 0);
        }
    }
}