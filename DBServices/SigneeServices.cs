using DBServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApI.Models;
using WebApI.Models.SigneeModels;

namespace WebApI.DBServices
{
    public class SigneeServices
    {
        public static DBConnectionServices dbconn;
        
        public static string CreateSignee_String(Signee signee)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("InsertSignee");
            dbconn.AddParameterToList("FirstName", SqlDbType.Text, signee.FirstName);
            dbconn.AddParameterToList("LastName", SqlDbType.Text, signee.LastName);

            dbconn.SetSqlParameters();

            return dbconn.ExecuteStoredProcedureString();
        }

        public static Signee GetSigneeByID_Signee(int signeeID)
        {
            Signee newSignee = new Signee();

            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("GetSigneeByID");
            dbconn.AddParameterToList("SigneeID", SqlDbType.Int, signeeID);
            dbconn.SetSqlParameters();

            foreach (DataRow signeeDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
            {
                newSignee = new Signee(signeeID, signeeDR["FirstName"].ToString(),
                    signeeDR["LastName"].ToString());
            }

            return newSignee;
        }

        public static List<Signee> GetSignees_ListSignee()
        {
            List<Signee> SigneeList = new List<Signee>();
            Signee newSignee = new Signee();

            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("GetSignees");

            foreach (DataRow signeeDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
            {
                newSignee = new Signee((int)signeeDR["SigneeID"], signeeDR["FirstName"].ToString(),
                   signeeDR["LastName"].ToString());

                SigneeList.Add(newSignee);
            }

            return SigneeList;
        }

        public static string UpdateSignee_String(Signee signee)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("UpdateSignee");

            dbconn.AddParameterToList("SigneeID", SqlDbType.Int, signee.ID);
            dbconn.AddParameterToList("FirstName", SqlDbType.Text, signee.FirstName);
            dbconn.AddParameterToList("LastName", SqlDbType.Text, signee.LastName);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }
        
        public static string DeleteSigneeByID_String(int signeeid)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("DeleteSignee");
            dbconn.AddParameterToList("SigneeID", SqlDbType.Int, signeeid);

            dbconn.SetSqlParameters();

            return dbconn.ExecuteStoredProcedureString();
        }
    }
}
