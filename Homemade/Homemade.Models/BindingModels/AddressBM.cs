namespace Homemade.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddressBM
    {
        [Required]
        public string Address { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public int ZIP { get; set; }

        public string Comments { get; set; }
    }
}
