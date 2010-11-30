using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class DefaultFilteringExtensionPoint<ItemToFilter, PropertyType> : FilteringExtensionPoint<ItemToFilter,PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public DefaultFilteringExtensionPoint(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.accessor = property_accessor;
        }

        public FilteringExtensionPoint<ItemToFilter, PropertyType> not
        {
            get
            {
                return new NegatingFilteringExtensionPoint<ItemToFilter, PropertyType>(this); 
            }
        }

        public Criteria<ItemToFilter> create_criteria_using(Criteria<PropertyType> real_criteria)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor, real_criteria);
        }
    }
}