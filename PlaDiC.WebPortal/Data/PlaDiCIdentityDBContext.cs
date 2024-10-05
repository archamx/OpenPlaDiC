using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PlaDiC.WebPortal.Data
{
    public class PlaDiCIdentityDBContext: IdentityDbContext<User, Role, string>
    {
        public PlaDiCIdentityDBContext(DbContextOptions<PlaDiCIdentityDBContext> options)
            :base(options)
        {
            
        }
    }
}
