using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{

    public class Where<ItemToFilter>
    {
        public static ICriteriaFactory<ItemToFilter,PropertyType> has_a<PropertyType>(
            Func<ItemToFilter, PropertyType> property_accessor) 
        {
            if(PropertyType is IComparable<ItemToFilter>)
            {
                return new ComparableCriteriaFactory<ItemToFilter, PropertyType>(property_accessor,new DefaultCriteriaFactory<ItemToFilter, PropertyType>(property_accessor));
            }

            return new DefaultCriteriaFactory<ItemToFilter, PropertyType>(property_accessor);
        }
    }
}