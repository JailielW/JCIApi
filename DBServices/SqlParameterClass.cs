using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DBServices
{
    public class SqlParameterClass
    {
        public string parametername { get; set; } 
        public SqlDbType sqldbtype { get; set; }
        public object parametervalue { get; set; }
        public ParameterDirection parameterDirection { get; set; }

        public SqlParameterClass()
        {

        }

        public SqlParameterClass(string pname,SqlDbType sqlparamtype,object pvalue, ParameterDirection paramDir = ParameterDirection.Input)
        {
            parametername = pname;
            sqldbtype = sqlparamtype;
            parametervalue = pvalue;
            parameterDirection = paramDir;
        }

        public SqlParameterClass(string pname, SqlDbType sqlparamtype,  ParameterDirection paramDir = ParameterDirection.Input)
        {
            parametername = pname;
            sqldbtype = sqlparamtype;
            parameterDirection = paramDir;
        }
    }
}
