using System;
namespace ShipBase.Models
{
	public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(Product product, int quantity)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            CartLine line = lineCollection
            .Where(p => p.Product.ProductID == product.ProductID)
            .FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (line == null)
            {
                lineCollection.Add(new CartLine
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
        public int GetQuantity(Product product)
        {
            return Lines.FirstOrDefault(l => l.Product.ProductID == product.ProductID)?.Quantity ?? 0;
        }

        public virtual void RemoveLine(Product product) => lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);

        public virtual decimal ComputeTax()
        {
            decimal tax = 0;
            decimal total = lineCollection.Sum(e => e.Product.Price * e.Quantity);
            const decimal taxRate = 0.07M;
            tax = total * taxRate;
            return tax;
        }
        public virtual decimal ComputeShipping()
        {
            decimal shipping;
            if (lineCollection.Sum(e => e.Product.Price * e.Quantity) >= 50)
            {
                 shipping = 0;
            }
            else
                 shipping = lineCollection.Sum(e => e.Product.Price * e.Quantity) * 0.2M;
            return shipping;
        }
        public virtual decimal ComputeTotalValue()
        {
            decimal sum =lineCollection.Sum(e => e.Product.Price * e.Quantity);
            decimal total = sum + ComputeTax() + ComputeShipping();
            return total;
        }
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
        
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Product Product { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int Quantity { get; set; }

        public int getQuantity()
        {
            return Quantity;
        }
    }
    
}

