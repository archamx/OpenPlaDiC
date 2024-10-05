using Microsoft.AspNetCore.Identity;

namespace PlaDiC.WebPortal.Data
{
    public class Role:IdentityRole
    {
        public string Tipo { get; set; }
    }
}
