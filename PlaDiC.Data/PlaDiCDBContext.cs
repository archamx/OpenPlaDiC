using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlaDiC.Entities;
using Object = PlaDiC.Entities.Object;

namespace PlaDiC.Data
{
    public class PlaDiCDBContext: DbContext
    {

        public PlaDiCDBContext(DbContextOptions<PlaDiCDBContext> options)
            :base(options)
        {

        }

        public DbSet<Object> Object { get; set; }
        public DbSet<ObjectProperty> ObjectProperty { get; set; }
        public DbSet<PickList> PickList { get; set; }
        public DbSet<PickListValue> PickListValue { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Object>().tToTable("Object");
        //    modelBuilder.Entity<ObjectProperty>().ToTable("ObjectProperty");
        //    modelBuilder.Entity<PickList>().ToTable("PickList");
        //}


    }
}
