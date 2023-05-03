namespace ShipBase.Models.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<Review> Reviews { get; set; } // add this line to hold the list of reviews
    }

}
