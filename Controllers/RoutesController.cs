using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApI.DBServices;
using WebApI.Models;
using WebApI.Models.RouteModels;

namespace WebApI.Controllers
{
    [Route("[controller]")]
    public class RoutesController : ControllerBase
    {
        [Route("GetRouteByID/{id}")]
        [HttpGet]
        public Route GetRouteByID(int id)
        {
            return RouteServices.GetRouteByID_Route(id);
        }

        [Route("GetRoutesByContract/{contractid}")]
        [HttpGet]
        public List<Route> GetRoutesByContract(int contractid)
        {
            return RouteServices.GetRoutesByContractID_ListRoute(contractid);
        }

        [Route("GetRoutes")]
        [HttpGet]
        public List<Route> GetRoutes()
        {
            return RouteServices.GetRoutes_ListRoute();
        }

        [Route("CreateRoutePickUp/{pickupname}")]
        [HttpPut]
        public string CreateRoutePickUp(string pickupname)
        {
            if (RouteServices.CreateRoutePickUp_String(pickupname).ToLower() == "Successful".ToLower())
            {
                return "Successfully Created!";
            }
            else
            {
                return RouteServices.CreateRoutePickUp_String(pickupname);
            }
        }

        [Route("CreateRouteDropOff/{routeid}/{dropoffname}")]
        [HttpPut]
        public string CreateRouteDropOff(int routeid, string dropoffname)
        {
            if (RouteServices.CreateRouteDropOff_String(routeid, dropoffname).ToLower() == "Successful".ToLower())
            {
                return "Succcessfully Created!";
            }
            else
            {
                return RouteServices.CreateRouteDropOff_String(routeid, dropoffname);
            }
        }

        [Route("UpdateRoute")]
        [HttpPut]
        public string UpdateRoute(Route route)
        {
            if (RouteServices.UpdateRoute_String(route).ToLower() == "Successful".ToLower())
            {
                return "Successfully Updated!";
            }
            else
            {
                return RouteServices.UpdateRoute_String(route);
            }
        }

        [Route("DeleteRoute/{routeid}")]
        [HttpDelete("{routeid}")]
        public string DeleteRoute(int routeid)
        {
            if (RouteServices.DeleteRouteByID_String(routeid).ToLower() == "Successful".ToLower())
            {
                return "Successfully Deleted!";
            }
            else
            {
                return RouteServices.DeleteRouteByID_String(routeid);
            }
        }
    }
}
