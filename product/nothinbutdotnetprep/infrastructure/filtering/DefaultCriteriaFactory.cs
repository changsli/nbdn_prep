using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class DefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;

        public DefaultCriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] properties)
        {
            return create_using(new EqualToAny<PropertyType>(properties));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return equal_to(value).not();
        }

        public Criteria<ItemToFilter> create_using(Criteria<PropertyType> real_criteria)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(property_accessor,
                                                                    real_criteria);
        }
    }
}