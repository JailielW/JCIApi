using DBServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApI.Models;
using WebApI.Models.LocationModels;

namespace WebApI.DBServices
{
    public class LocationServices
    {
        public static DBConnectionServices dbconn;
        
        public static string CreateLocation_String(Location location)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("InsertLocation");
            dbconn.AddParameterToList("LocationName", SqlDbType.Text, location.LocationName);
            dbconn.AddParameterToList("Address", SqlDbType.Text, location.Address);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }

        public static Location GetLocationByID_Location(int locationID)
        {
            Location newLocation = new Location();

            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("GetLocationByID");
            dbconn.AddParameterToList("LocationID", SqlDbType.Int, locationID);
            dbconn.SetSqlParameters();

            foreach (DataRow locationDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
            {
                newLocation = new Location(locationID, locationDR["LocationName"].ToString(), 
                    locationDR["Address"].ToString());
            }

            return newLocation;
        }

        public static List<Location> GetLocations_ListLocation()
        {
            List<Location> LocationList = new List<Location>();
            Location newLocation = new Location();

            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("GetLocations");

            foreach (DataRow contractDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
            {
                newLocation = new Location((int)contractDR["LocationID"], contractDR["LocationName"].ToString(),
                   contractDR["Address"].ToString());

                LocationList.Add(newLocation);
            }

            return LocationList;
        }

        public static string UpdateLocation_String(Location location)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("UpdateLocation");

            dbconn.AddParameterToList("locationid", SqlDbType.Int, location.ID);
            dbconn.AddParameterToList("locationname", SqlDbType.Text, location.LocationName);
            dbconn.AddParameterToList("address", SqlDbType.Text, location.Address);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }

        public static Location UpdateLocation_Location(Location location)
        {
            Location updatedLocation = new Location();

            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("UpdateLocation");

            dbconn.AddParameterToList("locationid", SqlDbType.Int, location.ID);
            dbconn.AddParameterToList("locationname", SqlDbType.Text, location.LocationName);
            dbconn.AddParameterToList("address", SqlDbType.Text, location.Address);

            dbconn.SetSqlParameters();

            foreach (DataRow locationDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
            {
                updatedLocation = new Location((int)locationDR["LocationID"], locationDR["LocationName"].ToString(),
                   locationDR["Address"].ToString());
                
            }

            return updatedLocation;
        }

        public static string DeleteLocationByID_String(int locationid)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("DeleteLocation");
            dbconn.AddParameterToList("LocationID", SqlDbType.Int, locationid);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }
    }
}
