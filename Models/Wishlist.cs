using System;
namespace ShipBase.Models
{
    public class Wishlist
    {
        private List<WishlistLine> lineCollection = new List<WishlistLine>();
        public virtual void AddItem(Product product, int quantity)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            WishlistLine line = lineCollection
            .Where(p => p.Product.ProductID == product.ProductID)
            .FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (line == null)
            {
                lineCollection.Add(new WishlistLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product) => lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);

        public virtual decimal ComputeTotalValue()
        {
            decimal sum = lineCollection.Sum(e => e.Product.Price * e.Quantity);
            decimal total = sum;
            return total;
        }
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<WishlistLine> Lines => lineCollection;
    }
    public class WishlistLine
    {
        public int WishlistLineID { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Product Product { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int Quantity { get; set; }
    }
}

