using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiesAuthorisationSample.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string DateOfBirth { get; set; }

        public IEnumerable<Users> GetUsers()
        {
            return new List<Users>()
            {
                new Users
                {
                     Id = 1,
                     UserName = "dev",
                     Name= "Dev",
                     Email="Dev@gmail.ro",
                     Password="Dev123456",
                     Role="Admin",
                     DateOfBirth="01/01/2000"
                }
            };
        }
    }
}
