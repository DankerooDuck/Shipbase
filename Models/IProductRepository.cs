using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ShipBase.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        IQueryable<Review> Reviews { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);

        void IncreaseProductAmount(Product product, int change);

        void DecreaseProductAmount(Product product, int change);


    }
}