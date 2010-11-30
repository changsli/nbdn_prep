using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter,PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> criteria_factory;

        public ComparableCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> criteria_factory)
        {
            this.criteria_factory = criteria_factory;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return create_using(new ExclusiveRangeWithNoUpperBound<PropertyType>(value).as_criteria());
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return criteria_factory.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> create_using(Criteria<PropertyType> real_criteria)
        {
            return criteria_factory.create_using(real_criteria);
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
            return create_using(start.up_to_and_including(end).as_criteria());
        }
    }
}