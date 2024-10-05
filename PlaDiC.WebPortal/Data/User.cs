using Microsoft.AspNetCore.Identity;

namespace PlaDiC.WebPortal.Data
{
    public class User:IdentityUser
    {
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Address { get; set; }
    }
}
