using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PlaDiC.Framework;

namespace PlaDiC.Data
{
    /// <summary>
    /// Clase que encapsula el acceso a datos a través de un objeto 
    /// referenciado a una base de datos en particular
    /// </summary>
    public  class DBContext 
    {

        private DBManager db;

        public DBManager DB
        {
            get { return db; }
            set { db = value; }
        }
                
        public DBContext(DataProvider providerType, string connectionString)
        {
            db = new DBManager(providerType, connectionString);
            db.Open();
        }

        public DBContext(DataProvider providerType, IDbConnection dbConnection)
        {
            db = new DBManager(providerType, dbConnection);
            db.Open();
        }

        public DBContext(DBManager dbRef)
        {
            db = dbRef;
            
        }
     
        public Response BeginTransaction()
        {
            Response res = new Response();
            try
            {
                db.BeginTransaction();
                res.IsSuccess = true;

            }
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "ERR: "+ex.Message;
            }
            return res;
        }

        public Response CommitTransaction()
        {
            Response res = new Response();
            try
            {
                db.CommitTransaction();
                res.IsSuccess = true;

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "ERR: " + ex.Message;
            }
            return res;
        }

        public Response RollBackTransaction()
        {
            Response res = new Response();
            try
            {
                db.RollBackTransaction();
                res.IsSuccess = true;

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "ERR: " + ex.Message;
            }
            return res;
        }

        public Response Execute(bool isSP, string code, params Parameter[] listParam)
        {
            List<Parameter> list = new List<Parameter>();
            foreach (Parameter p in listParam)
            {
                list.Add(p);
            }
            return Execute(isSP, code, list);

        }

        private Response Execute(bool isSP, string code, List<Parameter> listParam)
        {
            Response aRes = new Response();
            int res = 0;
                        
            StringBuilder str = new StringBuilder();

            str.Append(code);

            if (listParam.Count > 0)
            {

                db.CreateParameters(listParam.Count);

                int i = 0;
                string strP;

                foreach (Parameter p in listParam)
                {
                    strP = "@" + p.Name;                     
                    db.AddParameters(i, strP, p.Value);
                    i++;
                }

            }



            try
            {
                res = db.ExecuteNonQuery( ( isSP? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text ), str.ToString());
                if (res > 0)
                {
                    aRes.IsSuccess = true;
                }
                else
                {
                    aRes.IsSuccess = false;
                    aRes.Message = "ERR_SIN_CAMBIOS";
                }
                

            }
            catch (Exception ex)
            {
                aRes.IsSuccess = false;
                aRes.Message =  "ERROR: "+ex.Message;

            }


            return aRes;

        }

        private Response Execute(bool isSP, string code, params object[] listParam)
        {
            List<Parameter> listParameters = new List<Parameter>();
            int iCount = 0;
            foreach (object o in listParam)
            {
                listParameters.Add(new Parameter("Param" + iCount.ToString(), o));
                iCount++;
            }
            return Execute(isSP, code, listParameters);
        }

        private Response<DataTable> GetData(bool isSP, string code, List<Parameter> listParam)
        {
            Response<DataTable> cRes = new Response<DataTable>();
            
            DataSet res = null;

            if (isSP)
            #region Ejecturar StoredProcedure
            {
                db.CreateParameters(listParam.Count);
                int iParam = 0;
                foreach (Parameter p in listParam)
                {
                    
                    db.AddParameters(iParam++, p.Name, p.Value);

                }

                try
                {
                    res = db.ExecuteDataSet(System.Data.CommandType.StoredProcedure, code);

                    if (res.Tables[0].Rows.Count > 0)
                    {
                        cRes.IsSuccess = true;

                        cRes.Data = res.Tables[0];

                    }
                    else
                    {
                        cRes.Message = "MSG_RESULTADO_NO_DISPONIBLE";
                    }

                }
                catch (Exception ex)
                {
                    cRes.IsException = true;
                    cRes.Message = "ERROR: " + ex.Message;

                }


                return cRes;



            }
            #endregion
            else
            #region Ejecutar sentencia SQL
            {

                StringBuilder str = new StringBuilder();


                str.Append(code);

                if (listParam.Count > 0)
                {

                    db.CreateParameters(listParam.Count);

                
                    int i = 0;
                    string strP;
                    foreach (Parameter p in listParam)
                    {
                        strP = "@" + p.Name;

                        db.AddParameters(i, strP, p.Value);

                        i++;
                    }

                
                }

                try
                {
                    res = db.ExecuteDataSet(System.Data.CommandType.Text, str.ToString());

                    if (res.Tables[0].Rows.Count > 0)
                    {
                        cRes.IsSuccess = true;

                        cRes.Data = res.Tables[0];

                    }
                    else
                    {
                        cRes.Message = "MSG_RESULTADO_NO_DISPONIBLE";
                    }

                }
                catch (Exception ex)
                {
                    cRes.IsException = true;
                    cRes.Message = "ERROR: " + ex.Message;

                }


                return cRes;
            }
            #endregion

        }

        public Response<DataTable> GetData(bool isSP, string code, params Parameter[] listParam)
        {
            List<Parameter> listParameters = new List<Parameter>();
            int iCount = 0;
            foreach (var p in listParam)
            {
                listParameters.Add(p);
                iCount++;
            }
            return GetData(isSP, code, listParameters);
        }

        private Response<object> GetScalar(bool isSP, string code, string field, List<Parameter> listParam)
        {
            Response<object> aRes = new Response<object>();
            object res = null;

            
            
            StringBuilder str = new StringBuilder();

            if (isSP)
                str.Append("select " + field + " from  ");

            str.Append(code);

            db.CreateParameters(listParam.Count);

            if (isSP)
                str.Append("(");

            int i = 0;
            string strP;
            foreach (Parameter p in listParam)
            {
                strP = "@"+p.Name;

                if (isSP)
                {
                    str.Append(strP);
                    if (i < listParam.Count - 1)
                        str.Append(",");
                }

                db.AddParameters(i, strP, p.Value);

                i++;
            }

            if (isSP)
                str.Append(")");

            try
            {
                res = db.ExecuteScalar(System.Data.CommandType.Text, str.ToString());
                if (res != null)
                {
                    aRes.IsSuccess = true;
                    aRes.Data =  res;
                }
                else
                {
                    aRes.IsSuccess = false;
                    aRes.Message = "ERR_DATOS_NO_ENCONTRADOS";
                }
            }
            catch (Exception ex)
            {

                aRes.IsSuccess = false;
                aRes.Message ="ERROR: " + ex.Message;
                aRes.IsException = true;


            }


            return aRes;

        }

        public Response<object> GetScalar(bool isSP, string code, string field, params Parameter[] listParam)
        {
            List<Parameter> list = new List<Parameter>();
            foreach (Parameter p in listParam)
            {
                list.Add(p);
            }
            return GetScalar(isSP, code, field, list);
        
        }

        public Response UpdateDataObject(string tableName, string keyField, object recordId, List<Field> fields)
        {
            Response aRes = new Response();
            int res = 0;

            
            db.CreateParameters(fields.Count + 1);

            db.AddParameters(fields.Count, "@"+keyField, recordId);

            StringBuilder sb = new StringBuilder();

            string strFields = "";
           

            int iCount = 0;
            foreach (Field f in fields)
            {
                if (iCount == 0)
                {
                    strFields += f.Name + " = @" + f.Name;
                }
                else
                {
                    strFields += ", " + f.Name + " = @" + f.Name;

                }

                db.AddParameters(iCount, f.Name, f.Value);

                iCount++;
            }



            sb.AppendLine(" update ");
            sb.AppendLine(tableName);
            sb.AppendLine(" set " + strFields + "  ");

            sb.AppendLine(" where "+keyField+" = @"+keyField);


            try
            {
                res = db.ExecuteNonQuery(System.Data.CommandType.Text, sb.ToString());
                if (res > 0)
                {
                    aRes.IsSuccess = true;
                }
                else
                {
                    aRes.IsSuccess = false;
                    aRes.Message = "ERR_SIN_CAMBIOS";
                }


            }
            catch (Exception ex)
            {
                aRes.IsSuccess = false;
                aRes.Message = "ERROR: " + ex.Message;

            }


            return aRes;

        }

        public Response UpdateDataObject(string tableName, string keyField, object recordId, params Field[] fields)
        {
            List<Field> listFields = new List<Field>();
            foreach (Field f in fields)
            {
                listFields.Add(f);
            }

            return UpdateDataObject(tableName, keyField, recordId, listFields);
        }

        public Response InsertDataObject(string tableName, List<Field> fields)
        {
            Response aRes = new Response();
            int res = 0;
                                  
            db.CreateParameters(fields.Count);


            StringBuilder sb = new StringBuilder();

            string strFields = "";
            string strParams = "";

            int iCount = 0;
            foreach (Field f in fields)
            {
                if (iCount == 0)
                {
                    strFields = f.Name;
                    strParams = "@" + f.Name;
                }
                else
                {
                    strFields += ", " + f.Name;
                    strParams += ", @" + f.Name;

                }

                db.AddParameters(iCount, "@" + f.Name, f.Value);

                iCount++;
            }

            sb.AppendLine(" Insert into ");
            sb.AppendLine(tableName);
            sb.AppendLine(" ( " + strFields + " ) ");

            sb.AppendLine(" values( " + strParams + " ) ");


            try
            {
                res = db.ExecuteNonQuery(System.Data.CommandType.Text, sb.ToString());
                if (res > 0)
                {
                    aRes.IsSuccess = true;
                }
                else
                {
                    aRes.IsSuccess = false;
                    aRes.Message = "ERR_SIN_CAMBIOS";
                }


            }
            catch (Exception ex)
            {
                aRes.IsSuccess = false;
                aRes.Message = "ERROR: " + ex.Message;

            }


            return aRes;

        }

        public Response InsertDataObject(string tableName, params Field[] fields)
        {
            List<Field> listFields = new List<Field>();
            foreach (Field f in fields)
            {
                listFields.Add(f);
            }

            return InsertDataObject(tableName, listFields);
        
        
        }

        public Response<DataRow> GetDataObject(string tableName, string keyField, object recordId)
        {
            Response<DataRow> cRes = new Response<DataRow>();

            DataSet res = null;
            db.CreateParameters(1);
            db.AddParameters(0, "@" + keyField, recordId);



            try
            {
                res = db.ExecuteDataSet(System.Data.CommandType.Text, "select * from " + tableName + " where " + keyField + " = @" + keyField);

                if (res.Tables[0].Rows.Count > 0)
                {
                    cRes.IsSuccess = true;

                    cRes.Data = res.Tables[0].Rows[0];

                }
                else
                {
                    cRes.Message = "MSG_NOT_FIELDS_AVAILABLE";
                }

            }
            catch (Exception ex)
            {
                cRes.IsException = true;
                cRes.Message = "ERROR: " + ex.Message;

            }


            return cRes;
        }

        public Response<DataTable> GetDataObjects(string tableName, string keyField, object recordId)
        {
            Response<DataTable> cRes = new Response<DataTable>();

            DataSet res = null;
            db.CreateParameters(1);
            db.AddParameters(0, "@" + keyField, recordId);



            try
            {
                res = db.ExecuteDataSet(System.Data.CommandType.Text, "select * from " + tableName + " where " + keyField + " = @" + keyField);

                if (res.Tables[0].Rows.Count > 0)
                {
                    cRes.IsSuccess = true;

                    cRes.Data = res.Tables[0];

                }
                else
                {
                    cRes.Message = "MSG_NOT_FIELDS_AVAILABLE";
                }

            }
            catch (Exception ex)
            {
                cRes.IsException = true;
                cRes.Message = "ERROR: " + ex.Message;

            }


            return cRes;
        }

        public Response DeleteDataObject(string tableName, string keyField, object recordId)
        {
            Response cRes = new Response();

            int res = 0;
            db.CreateParameters(1);
            db.AddParameters(0, "@" + keyField, recordId);



            try
            {
                res = db.ExecuteNonQuery(System.Data.CommandType.Text, "Delete from " + tableName + " where " + keyField + " = @" + keyField);

                if (res > 0)
                {
                    cRes.IsSuccess = true;


                }
                else
                {
                    cRes.Message = "MSG_NOTCHANGES";
                }

            }
            catch (Exception ex)
            {
                cRes.IsException = true;
                cRes.Message = "ERROR: " + ex.Message;

            }


            return cRes;
        }

    }
}
