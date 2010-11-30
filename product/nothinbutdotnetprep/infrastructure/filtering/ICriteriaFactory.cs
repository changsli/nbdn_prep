namespace nothinbutdotnetprep.infrastructure.filtering
{
    public interface CriteriaFactory<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> equal_to(PropertyType value_to_equal);
        Criteria<ItemToFilter> equal_to_any(params PropertyType[] properties);
        Criteria<ItemToFilter> not_equal_to(PropertyType value);
        Criteria<ItemToFilter> create_using(Criteria<PropertyType> real_criteria);
    }
}