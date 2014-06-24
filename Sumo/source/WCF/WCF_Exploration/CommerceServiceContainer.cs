namespace WCF_Exploration
{
    public class CommerceServiceContainer : ICommerceServiceContainer
    {
        public IProductManagementService ResolveProductManagementService()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings("CommerceObjectContext");

            ProductRepository repository =
                new SqlProductRepository(connectionString);

            IContractMapper mapper = new ContractMapper();

            return new ProductManagementService(repository,
                mapper);
        }

        public void Release(object instance)
        {
        }
    }
}