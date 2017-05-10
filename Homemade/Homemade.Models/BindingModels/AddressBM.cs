namespace Homemade.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddressBM
    {
        [Display(Name = "Shipping Address")]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Invalid address.")]
        public string ShippingAddress { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required(ErrorMessage = "Invalid town.")]
        public string Town { get; set; }

        public string Description { get; set; }
    }
}
