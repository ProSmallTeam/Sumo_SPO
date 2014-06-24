namespace WCF_Exploration
{
    public interface ICommerceServiceContainer
    {
        void Release(object instance);

        IProductManagementService ResolveProductManagementService();
    }
}