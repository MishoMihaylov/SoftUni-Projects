namespace Homemade.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public HomemadeUser User { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Town is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Invalid town name. Town name must be between 2 and 50 symbols")]
        public string Town { get; set; }

        [Required(ErrorMessage = "ZIPCode is required")]
        public int ZIPCode { get; set; }

        public string Comment { get; set; }
    }
}
