namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class NegatingFilteringExtensionPoint<ItemToFilter, PropertyType> : FilteringExtensionPoint<ItemToFilter,PropertyType>
    {
        FilteringExtensionPoint<ItemToFilter, PropertyType> extension_point;

        public NegatingFilteringExtensionPoint(FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point)
        {
            this.extension_point = extension_point;
        }

        public Criteria<ItemToFilter> create_criteria_using(Criteria<PropertyType> real_criteria)
        {
            return extension_point.create_criteria_using(real_criteria).not();
        }
    }
}