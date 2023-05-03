using System.ComponentModel.DataAnnotations;

namespace ShipBase.Models.ViewModels
{
    public class ReviewViewModel
    {
        public int ProductID { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        [StringLength(50, ErrorMessage = "The title must be between {2} and {1} characters long.", MinimumLength = 5)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter a review")]
        [StringLength(500, ErrorMessage = "The review must be between {2} and {1} characters long.", MinimumLength = 10)]
        public string? Comment { get; set; }
    }
}
