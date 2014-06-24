using System;
using System.Collections.Generic;

namespace WCF_Exploration
{
    public class SqlProductRepository : ProductRepository
    {
        public SqlProductRepository(string connectionString)
        {
            throw new NotImplementedException();
        }

        public override void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public override Product SelectProduct(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Product> SelectAllProducts()
        {
            throw new NotImplementedException();
        }

        public override void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Product> GetFeaturedProducts()
        {
            throw new NotImplementedException();
        }
    }
}