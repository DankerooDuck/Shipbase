namespace ShipBase.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;

        public IQueryable<Review> Reviews => context.Reviews;

        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Product> Products => context.Products;

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                Product dbEntry = context.Products
                .FirstOrDefault(p => p.ProductID == product.ProductID); if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.Weight = product.Weight;
                    dbEntry.Brand = product.Brand;
                    dbEntry.ImageURL = product.ImageURL;
                    dbEntry.AttributeName = product.AttributeName;
                    dbEntry.AttributeNameValue = product.AttributeNameValue;
                    dbEntry.Width = product.Width;
                    dbEntry.Height = product.Height;
                    dbEntry.Length= product.Length;
                    dbEntry.Amount = product.Amount;
                    dbEntry.Reviews = product.Reviews;
                }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Product dbEntry = context.Products
                .FirstOrDefault(p => p.ProductID == productID);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
#pragma warning disable CS8603 // Possible null reference return.
            return dbEntry;
#pragma warning restore CS8603 // Possible null reference return.
        }
        public  void IncreaseProductAmount(Product product, int change)
        {

            product.Amount += change;
            context.SaveChanges();
        }
        public  void DecreaseProductAmount(Product product, int change)
        {

            if (product.Amount - change >= 0)
            {
                product.Amount -= change;
            }
            else
            {
                product.Amount = -1;
            }

            
        
            context.SaveChanges();
        }
    }
}

