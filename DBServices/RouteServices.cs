using DBServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApI.Models;
using WebApI.Models.RouteModels;

namespace WebApI.DBServices
{
    public class RouteServices
    {
        public static DBConnectionServices dbconn;

        public static string CreateRoutePickUp_String(string pickuplocationname)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("InsertRoutePickUp");
            dbconn.AddParameterToList("pickuptime", SqlDbType.DateTime, DateTime.Now);
            dbconn.AddParameterToList("pickuplocationname", SqlDbType.Text, pickuplocationname);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }

        public static string CreateRouteDropOff_String(int routeid,string dropofflocationname)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("InsertRouteDropOff");

            dbconn.AddParameterToList("dropofftime", SqlDbType.DateTime, DateTime.Now);
            dbconn.AddParameterToList("dropofflocationname", SqlDbType.Text, dropofflocationname);
            dbconn.AddParameterToList("routeid", SqlDbType.Int, routeid);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }

        public static Route GetRouteByID_Route(int routeid)
        {
            Route route = new Route();

            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("GetRouteByID");
            dbconn.AddParameterToList("routeid", SqlDbType.Int, routeid);

            dbconn.SetSqlParameters();

            if(dbconn.ExecuteStoredProcedureDataTable().Rows.Count == 1)
            {
                foreach (DataRow routeDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
                {
                    object dropofftime = ValueValidater.ReturnValue(routeDR["DropOffTime"]);
                    object dropofflocation = ValueValidater.ReturnValue(routeDR["DropOffLocation"]);
                    
                    if(dropofftime != null && dropofflocation != null)
                    {
                        route = new Route(routeid, routeDR["PickupTime"].ToString(),routeDR["PickUpLocation"].ToString(),
                            (Status)routeDR["StatusID"],dropofftime.ToString(),dropofflocation.ToString());
                    }
                    else
                    {
                        route = new Route(routeid, routeDR["PickupTime"].ToString(), routeDR["PickUpLocation"].ToString(),
                            (Status)routeDR["StatusID"], null, null);
                    }
                }
            }
            
            return route;
        }

        public static List<Route> GetRoutesByContractID_ListRoute(int contractid)
        {
            List<Route> RouteList = new List<Route>();
            Route newRoute = new Route();

            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("GetRoutesByContract");
            
            dbconn.AddParameterToList("contractid", SqlDbType.Int, contractid);
            dbconn.SetSqlParameters();

            foreach (DataRow routeDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
            {
                newRoute = new Route((int)routeDR["RouteID"], routeDR["PickupTime"].ToString(),
                    routeDR["PickupLocation"].ToString(), (Status)routeDR["StatusID"]
                    , routeDR["DropOffTime"].ToString(), routeDR["DropoffLocation"].ToString());

                RouteList.Add(newRoute);
            }

            return RouteList;
        }

        public static List<Route> GetRoutes_ListRoute()
        {
            List<Route> RouteList = new List<Route>();
            Route newRoute = new Route();

            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("GetRoutes");

            foreach (DataRow routeDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
            {
                newRoute = new Route((int)routeDR["RouteID"], routeDR["PickupTime"].ToString(),
                    routeDR["PickupLocation"].ToString(),(Status)routeDR["Status"]
                    ,routeDR["DropOffTime"].ToString(), routeDR["DropoffLocation"].ToString());

                RouteList.Add(newRoute);
            }

            return RouteList;
        }

        public static string UpdateRoute_String(Route route)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("UpdateRoute");

            dbconn.AddParameterToList("routeid", SqlDbType.Int, route.ID);
            dbconn.AddParameterToList("pickuptime", SqlDbType.DateTime, Convert.ToDateTime(route.PickUpTime));
            dbconn.AddParameterToList("dropofftime", SqlDbType.DateTime,Convert.ToDateTime(route.DropOffTime));
            dbconn.AddParameterToList("pickuplocation", SqlDbType.Text, route.PickUpLocation.LocationName);
            dbconn.AddParameterToList("dropofflocation", SqlDbType.Text, route.DropOffLocation.LocationName);
            dbconn.AddParameterToList("status", SqlDbType.Int, (int)route.Status);

            dbconn.SetSqlParameters();

            return dbconn.ExecuteStoredProcedureString();
        }

        public static string DeleteRouteByID_String(int routeid)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("DeleteRoute");
            dbconn.AddParameterToList("routeid", SqlDbType.Int, routeid);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }
    }
}
