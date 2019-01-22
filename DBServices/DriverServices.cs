using DBServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApI.Models;
using WebApI.Models.DriverModels;

namespace WebApI.DBServices
{
    public static class DriverServices
    {
        private static DBConnectionServices dbconn;
        
        public static string CreateDriver_String(Driver driver)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("InsertDriver");
            dbconn.AddParameterToList("FirstName", SqlDbType.Text, driver.FirstName);
            dbconn.AddParameterToList("LastName", SqlDbType.Text, driver.LastName);
            dbconn.AddParameterToList("StartDate", SqlDbType.Date, driver.StartDate);
            dbconn.AddParameterToList("EndDate", SqlDbType.Date, driver.EndDate);
            dbconn.AddParameterToList("BadgeNumber", SqlDbType.Text, driver.BadgeNumber);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }

        public static Driver GetDriverByID_Driver(int driverID)
        {
            Driver newDriver = new Driver();

            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("GetDriverByID");
            dbconn.AddParameterToList("DriverID", SqlDbType.Int, driverID);
            dbconn.SetSqlParameters();

            if (dbconn.ExecuteStoredProcedureDataTable().Rows.Count == 1)
            {
                foreach (DataRow driverDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
                {
                    object dropofftime = ValueValidater.ReturnValue(driverDR["DropOffTime"]);
                    object dropofflocation = ValueValidater.ReturnValue(driverDR["DropOffLocation"]);

                    if (dropofftime != null && dropofflocation != null)
                    {
                        newDriver = new Driver(driverID, driverDR["FirstName"].ToString(),
                            driverDR["LastName"].ToString(), driverDR["BadgeNumber"].ToString(),
                            driverDR["StartDate"].ToString(), driverDR["EndDate"].ToString());
                    }
                    else
                    {
                        newDriver = new Driver(driverID, driverDR["FirstName"].ToString(),
                            driverDR["LastName"].ToString(), driverDR["BadgeNumber"].ToString(),
                            driverDR["StartDate"].ToString(), driverDR["EndDate"].ToString());
                    }
                }
            }

            return newDriver;
        }

        public static List<Driver> GetDrivers_ListDriver()
        {
            List<Driver> DriverList = new List<Driver>();
            Driver newDriver = new Driver();

            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("GetDrivers");

            foreach (DataRow driverDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
            {
                object dropofftime = ValueValidater.ReturnValue(driverDR["DropOffTime"]);
                object dropofflocation = ValueValidater.ReturnValue(driverDR["DropOffLocation"]);

                if (dropofftime != null && dropofflocation != null)
                {
                    newDriver = new Driver((int)driverDR["DriverID"], driverDR["FirstName"].ToString(),
                        driverDR["LastName"].ToString(), driverDR["BadgeNumber"].ToString(),
                        driverDR["StartDate"].ToString(), driverDR["EndDate"].ToString());
                }
                else
                {
                    newDriver = new Driver((int)driverDR["DriverID"], driverDR["FirstName"].ToString(),
                        driverDR["LastName"].ToString(), driverDR["BadgeNumber"].ToString(),
                        driverDR["StartDate"].ToString(), driverDR["EndDate"].ToString());
                }
            }

            return DriverList;
        }

        public static string UpdateDriver_String(Driver driver)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("UpdateDriver");

            dbconn.AddParameterToList("DriverID", SqlDbType.Int, driver.ID);
            dbconn.AddParameterToList("FirstName", SqlDbType.Text, driver.FirstName);
            dbconn.AddParameterToList("LastName", SqlDbType.Text, driver.LastName);
            dbconn.AddParameterToList("StartDate", SqlDbType.Date, driver.StartDate);
            dbconn.AddParameterToList("EndDate", SqlDbType.Date, driver.EndDate);
            dbconn.AddParameterToList("BadgeNumber", SqlDbType.Text, driver.BadgeNumber);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }
        
        public static string DeleteDriverByID_String(int driverid)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("DeleteDriver");
            dbconn.AddParameterToList("DriverID", SqlDbType.Int, driverid);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }
    }
}
