namespace nothinbutdotnetprep.infrastructure.filtering
{
    public interface FilteringExtensionPoint<ItemToFilter,PropertyType>
    {
        Criteria<ItemToFilter> create_criteria_using(Criteria<PropertyType> real_criteria);
    }
}