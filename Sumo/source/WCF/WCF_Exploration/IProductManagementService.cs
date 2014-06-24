using System.ServiceModel;

namespace WCF_Exploration
{
    [ServiceContract]
    public interface IProductManagementService
    {
        [OperationContract]
        void DeleteProduct(int productId);

        [OperationContract]
        void InsertProduct(ProductContract product);

        [OperationContract]
        ProductContract SelectProduct(int productId);

        [OperationContract]
        ProductContract[] SelectAllProducts();

        [OperationContract]
        void UpdateProduct(ProductContract product);
    }
}