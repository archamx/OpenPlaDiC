using PlaDiC.Data;
using PlaDiC.Framework;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaDiC.Biz
{
    public class Core
    {
        public Response<System.Data.DataTable> ExecSP(string procName, params Parameter[] listParam)
        {

            bool debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["SP_DEBUG"] ?? "false");

            if (debug)
            {
                try
                {
                    string rutaDebug = (System.Configuration.ConfigurationManager.AppSettings["LOG_PATH"] ?? ("C:\\LOGS\\"));

                    string log = "";

                    log += procName + "\n\n";

                    if (listParam != null)
                    {
                        log += "Parámetros:\n";

                        foreach (var item in listParam)
                        {
                            log += "Nombre: " + item.Name + ", Valor: " + item.Value + "\n";
                        }
                    }



                    System.IO.File.WriteAllText(rutaDebug + System.DateTime.Now.ToString("yyyyMMddhhmmsszzz") + ".log", log);
                }
                catch (Exception e)
                {

                }

            }
            try
            {
                PlaDiC.Data.DBManager context = new Data.DBManager("FB_PlaDiC");
                var d = context.ExecuteDataSet(System.Data.CommandType.StoredProcedure, procName, listParam);
                return new Response<System.Data.DataTable>() 
                { 
                    IsSuccess = true,
                    Data = d != null && d.Tables != null && d.Tables.Count > 0 ? d.Tables[0] : null
                };

            }
            catch (Exception ex)
            {

                return new Response<System.Data.DataTable>() { IsException = true, Message = ex.Message };
            }
            
        }


        public Response<System.Data.DataTable> ExecSQL(string SqlQuery, params Parameter[] listParam)
        {

            bool debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["SQL_DEBUG"] ?? "false");

            if (debug)
            {
                try
                {

                    string rutaDebug = (System.Configuration.ConfigurationManager.AppSettings["LOG_PATH"] ?? ("C:\\LOGS\\"));
                    string log = "";

                    log += SqlQuery + "\n\n";

                    if (listParam != null)
                    {
                        log += "Parámetros:\n";

                        foreach (var item in listParam)
                        {
                            log += "Nombre: " + item.Name + ", Valor: " + item.Value + "\n";
                        }
                    }



                    System.IO.File.WriteAllText(rutaDebug + System.DateTime.Now.ToString("yyyyMMddhhmmsszzz") + ".log", log);
                }
                catch (Exception e)
                {

                }

            }

            try
            {
                PlaDiC.Data.DBManager context = new Data.DBManager("FB_PlaDiC");
                var d = context.ExecuteDataSet(System.Data.CommandType.Text, SqlQuery, listParam);
                return new Response<System.Data.DataTable>()
                {
                    IsSuccess = true,
                    Data = d != null && d.Tables != null && d.Tables.Count > 0 ? d.Tables[0] : null
                };

            }
            catch (Exception ex)
            {

                return new Response<System.Data.DataTable>() { IsException = true, Message = ex.Message };
            }
        }


        public Response ExecRazorCode(string razorCode, string referenceName, params Parameter[] listParam)
        {

            try
            {

                Request request = new Request();


                if (listParam != null)
                {
                    request.Parameters = listParam.ToList();
                }


                var templateConfig = new TemplateServiceConfiguration
                {
                    TemplateManager = new DelegateTemplateManager(controllerAndAction => razorCode),
                    DisableTempFileLocking = true,
                    CachingProvider = new DefaultCachingProvider(t => { })
                };
                //var actionController = $"{controller}/{action}.cshtml";

                var engine = RazorEngineService.Create(templateConfig);


                var html = engine.RunCompile(razorCode, request.GetType(), request);

                html = html.Replace("\n", "");
                html = html.Replace("\r", "");

                return new Response() { IsSuccess = true, Message = html };


            }
            catch (Exception ex)
            {

                return new Response() { IsException = true, Message = ex.Message };
            }


        }

        public Response<DataTable> GetSql(IDbConnection connection, string SqlQuery, params Parameter[] listParam)
        {

            try
            {
                DBContext context = new DBContext(DataProvider.FB, connection);

                return context.GetData(false, SqlQuery, listParam);


            }
            catch (Exception ex)
            {
                return new Response<DataTable> { IsException = true, InnerException = ex.Message };
            }


            

        }

    }

}
