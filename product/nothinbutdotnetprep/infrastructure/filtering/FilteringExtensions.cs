using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class FilteringExtensions
    {
        public static Criteria<ItemToFilter> equal_to_any<ItemToFilter,PropertyType>(
            this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,
            params PropertyType[] properties)
        {
            return create_using(extension_point, new EqualToAny<PropertyType>(properties));
        }

        public static Criteria<ItemToFilter> equal_to<ItemToFilter,PropertyType>(
            this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,
            PropertyType value_to_equal)
        {
            return extension_point.equal_to_any(value_to_equal);
        }

        public static Criteria<ItemToFilter> greater_than<ItemToFilter,PropertyType>(
            this FilteringExtensionPoint<ItemToFilter,PropertyType>  extension_point
            ,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return create_using(extension_point,
                                new ExclusiveRangeWithNoUpperBound<PropertyType>(value).as_criteria());
        }
        
        public static Criteria<ItemToFilter> between<ItemToFilter,PropertyType>(
            this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point, 
            PropertyType start,PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return create_using(extension_point,start.up_to_and_including(end).as_criteria());
        }

        static Criteria<ItemToFilter> create_using<ItemToFilter,PropertyType>(FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,Criteria<PropertyType> real_criteria)
        {
            return extension_point.create_criteria_using(real_criteria);
        }
    }
}