using Microsoft.EntityFrameworkCore;
using PlaDiC.Data;
using PlaDiC.Framework;
using PlaDiC.WebPortal.Data;
using System.Data;

namespace PlaDiC.WebPortal
{
    public static class ViewHelper
    {

        private static string _connStr;

        public static void Configure(string connectionString)
        {
            _connStr = connectionString;
        }
        public static Response<DataTable> GetSql(string sql, params Parameter[] parameters) 
        {

            PlaDiC.Biz.Core biz = new Biz.Core();

            var connectionstring = _connStr;

            var optionsBuilder = new DbContextOptionsBuilder<PlaDiCDBContext>();
            optionsBuilder.UseFirebird(connectionstring);


            using (PlaDiCDBContext dbContext = new PlaDiCDBContext(optionsBuilder.Options))
            {
                return biz.GetSql(dbContext.Database.GetDbConnection(), sql, parameters);

            }


        }
    }
}
