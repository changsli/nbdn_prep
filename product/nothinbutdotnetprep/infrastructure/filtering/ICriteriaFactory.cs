using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public interface ICriteriaFactory<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> greater_than(PropertyType value);
        Criteria<ItemToFilter> equal_to(PropertyType value_to_equal);
        Criteria<ItemToFilter> equal_to_any(params PropertyType[] properties);
        Criteria<ItemToFilter> not_equal_to(PropertyType value);
    }
}
