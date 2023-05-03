using System.ComponentModel.DataAnnotations;

namespace ShipBase.Models
{
    public class Review
    {
        // REVIEW ID
        public int ReviewID { get; set; }

        // REVIEW CONTENT
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        [StringLength(50, ErrorMessage ="Title cannot be longer than 50 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter a review")]
        [StringLength(500, ErrorMessage = "Review cannot be longer than 500 characters.")]
        public string? Comment { get; set; }

        // REVIEW INFO
        public DateTime PostedDate { get; set; }

        public int ProductID { get; set; }

        // Reference to Product
        public Product Product { get; set; }

        // Reference to User
        public AppUser? User { get; set; }

        public IEnumerable<Review>? Reviews { get; set;}
    }
}
