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
            return new AnonymousCriteria<ItemToFilter>(x => property_accessor(x).Equals(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] properties)
        {
            return
                new AnonymousCriteria<ItemToFilter>(
                    x => (properties as IList<PropertyType>).Contains(property_accessor(x)));
        }
    }
}