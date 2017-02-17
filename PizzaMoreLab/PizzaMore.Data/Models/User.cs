using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.Data.Models
{
    public class User
    {
        public User()
        {
            this.Suggestions = new HashSet<Pizza>();
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        ICollection<Pizza> Suggestions { get; set; }
    }
}
