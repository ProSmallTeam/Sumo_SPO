using System.Collections.Generic;

namespace WCF_Exploration
{
    public interface IContractMapper
    {
        MoneyContract Map(Money money);

        Money Map(MoneyContract moneyContract);

        ProductContract Map(Product product);

        IEnumerable<ProductContract> Map(IEnumerable<Product> products);

        Product Map(ProductContract productContract);
    }
}