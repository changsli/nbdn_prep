using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{

    public class Where<ItemToFilter>
    {
        public static DefaultFilteringExtensionPoint<ItemToFilter,PropertyType> has_a<PropertyType>(
            Func<ItemToFilter, PropertyType> property_accessor) 
        {
            return new DefaultFilteringExtensionPoint<ItemToFilter, PropertyType>(property_accessor);
        }

    }
}