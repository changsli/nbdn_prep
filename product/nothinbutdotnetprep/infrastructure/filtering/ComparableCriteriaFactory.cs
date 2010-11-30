using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>,ICriteriaFactory<ItemToFilter,PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;
        private DefaultCriteriaFactory<ItemToFilter, PropertyType> defaultCriteria;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor,DefaultCriteriaFactory<ItemToFilter,PropertyType> criteria)
        {
            this.property_accessor = property_accessor;
            this.defaultCriteria = criteria;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(x => property_accessor(x).CompareTo(value) > 0);
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return this.defaultCriteria.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] properties)
        {

            return this.defaultCriteria.equal_to_any(properties);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return this.defaultCriteria.not_equal_to(value);
        }
    }
}