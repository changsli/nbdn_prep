using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class PropertyCriteria<ItemToFilter,PropertyType> : Criteria<ItemToFilter>
    {
        Func<ItemToFilter, PropertyType> property_accessor;
        Criteria<PropertyType> actual_criteria;

        public PropertyCriteria(Func<ItemToFilter, PropertyType> property_accessor, Criteria<PropertyType> actual_criteria)
        {
            this.property_accessor = property_accessor;
            this.actual_criteria = actual_criteria;
        }

        public bool matches(ItemToFilter item)
        {
            return actual_criteria.matches(property_accessor(item));
        }
    }
}