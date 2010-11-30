using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class Where<ItemToFilter>
    {
        public static Where<ItemToFilter> has_a(Func<Movie, ProductionStudio> func)
        {
            return new Where<ItemToFilter>();
        }

        public Criteria<ItemToFilter> equal_to(ProductionStudio pixar)
        {
            throw new NotImplementedException();
        }
    }
}