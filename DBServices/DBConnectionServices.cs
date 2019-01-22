using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBServices
{
    public class DBConnectionServices
    {
        public string connectionstring { get; set; }
        public SqlConnection con { get; set; }
        public SqlCommand command { get; set; }
        private List<SqlParameterClass> ListSqlParameterClass = new List<SqlParameterClass>();

        //Set Default JCI Connection String
        /*public DBConnectionServices()
        {
            connectionstring = ConfigurationManager.ConnectionStrings["JCIConnection"].ConnectionString;
            OpenConnection();
        }
        */
        //Set Connection String on initialization of Class
        //public DBConnectionServices(string connstring)
        //{
        //    connectionstring = connstring;
        //    con = new SqlConnection(connectionstring);

        //    con.Open();
        //}

        //Pass in database name that is stored in config file
        public DBConnectionServices(string databasename)
        {
            connectionstring = ConfigurationManager.ConnectionStrings[databasename].ConnectionString;
            OpenConnection();
        }

        public DBConnectionServices()
        {
        }

        //Open Connection
        public void OpenConnection()
        {
            con = new SqlConnection(connectionstring);
            con.Open();
        }

        //Close Connection
        public void CloseConnection()
        {
            con.Close();
        }

        //Return Connection State of SqlConnection
        public ConnectionState Connectionstate()
        {
            return con.State;
        }

        //Set stored procedure name to command variable
        public void SetSqlCommandStoredProcedure(string storedporcedurename)
        {
            if(con.State != ConnectionState.Closed)
            {
                command = new SqlCommand(storedporcedurename, con);
                command.CommandType = CommandType.StoredProcedure;
            }
        }

        //Sets query string to command variable
        public bool SetSqlCommandQueryString(string querystring)
        {
            if (con.State != ConnectionState.Closed)
            {
                command = new SqlCommand(querystring, con);
                return true;
            }

            return false;
        }

        //Adds Sql Parameters to List<SqlParameterClass>
        public void AddParameterToList(string parametername,SqlDbType dbtype = SqlDbType.Variant,object parametervalue = null,ParameterDirection parameterdirection = ParameterDirection.Input)
        {
            if (!string.IsNullOrEmpty(parametername))
            {
                ListSqlParameterClass.Add(new SqlParameterClass(parametername,dbtype,parametervalue,parameterdirection)); 
            }
        }

        //public bool SetSqlParameter(SqlParameterClass sqlParameterClass)
        //{
        //    try
        //    {
        //        command = new SqlCommand();
        //        command.Parameters.Add(new SqlParameter(sqlParameterClass.parametername,sqlParameterClass.sqldbtype));
        //        command.Parameters[sqlParameterClass.parametername].Value = sqlParameterClass.parametervalue;
        //        command.Parameters[sqlParameterClass.parametername].Direction = sqlParameterClass.parameterDirection;
        //        return true;
        //    }
        //    catch(SqlException ex)
        //    {
        //        //debugging
        //        //string message = ex.Message;
        //        return false;
        //    }
        //}

        //Set command Sql parameters for stored procedure
        //Returns bool value depending on if the implementation succeeded or not
        public bool SetSqlParameters()
        {
            try
            {
                foreach (SqlParameterClass sqlparamcls in ListSqlParameterClass)
                {
                    command.Parameters.Add(new SqlParameter("@" + sqlparamcls.parametername, sqlparamcls.sqldbtype));
                    command.Parameters["@" + sqlparamcls.parametername].Value = sqlparamcls.parametervalue;
                    command.Parameters["@" + sqlparamcls.parametername].Direction = sqlparamcls.parameterDirection;

                    if(command.Parameters["@" + sqlparamcls.parametername].Direction == ParameterDirection.Output)
                    {
                        command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    }
                }
                
                //Clear List
                ListSqlParameterClass = new List<SqlParameterClass>();

                return true;
            }
            catch(SqlException ex)
            {
                //debugging
                string message = ex.Message;
                return false;
            }
        }

        //Execute Stored Procedure that doesn't have any returned Values
        //Returns number of rows affected by query
        public int ExecuteStoredProcedureInt()
        {
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
        }

        public string ExecuteStoredProcedureString()
        {
            try
            {
                command.ExecuteNonQuery();
                return "Successful";
            }
            catch(SqlException ex)
            {
                return ex.Message;
            }
        }

        public DataTable ExecuteStoredProcedureDataTable()
        {
            DataTable datatable = new DataTable();
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(datatable);

                return datatable;
            }
            catch
            {
                return null;
            }
        }

        //Return Dictionary of output parameters
        //Key: Parameter Name
        //Value: Parameter Value
        public Dictionary<string, object> ExecuteStoredProcedureWithOutputParameters()
        {
            Dictionary<string, object> OutputParameterNameValue = new Dictionary<string, object>();
            OutputParameterNameValue = null;
            try
            {
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                ExecuteStoredProcedureString();
                foreach (SqlParameterClass outputparam in ListSqlParameterClass)
                {
                    if(outputparam.parameterDirection == ParameterDirection.Output)
                    {
                        OutputParameterNameValue.Add(outputparam.parametername, command.Parameters[string.Format("@{0}", outputparam.parametername)].Value);
                    }
                }
                
                return OutputParameterNameValue;
            }
            catch(SqlException ex)
            {
                //debugging
                string message = ex.Message;
                return OutputParameterNameValue;
            }
        }
    }
}
