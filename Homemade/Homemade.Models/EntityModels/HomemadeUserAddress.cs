namespace Homemade.Models.EntityModels
{
    public class HomemadeUserAddress
    {
        public int Id { get; set; }

        public HomemadeUser User { get; set; }

        public string Street { get; set; }

        public string Town { get; set; }

        public string ZIPCode { get; set; }

        public string Comment { get; set; }
    }
}
