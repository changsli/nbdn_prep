using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;

        public CriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] properties)
        {
            return
                new AnonymousCriteria<ItemToFilter>(
                    x => (properties as IList<PropertyType>).Contains(property_accessor(x)));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return equal_to(value).not();
        }

        public Criteria<Movie> greater_than(int value)
        {
            return
                new AnonymousCriteria<ItemToFilter>(
                    x => ((int)property_accessor(x)) >  value);
        }
    }
}