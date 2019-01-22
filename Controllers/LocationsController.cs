using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApI.DBServices;
using WebApI.Models;
using WebApI.Models.LocationModels;

namespace WebApI.Controllers
{
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        [Route("CreateLocation")]
        [HttpPut]
        public string CreateLocation(Location location)
        {
            if (LocationServices.CreateLocation_String(location).ToLower() == "Successful".ToLower())
            {
                return "Successfully Created!";
            }
            else
            {
                return LocationServices.CreateLocation_String(location);
            }
        }

        [Route("GetLocation/{id}")]
        [HttpGet]
        public Location GetLocation(int id)
        {
            return LocationServices.GetLocationByID_Location(id);
        }

        [Route("GetLocations")]
        [HttpGet]
        public List<Location> GetLocations()
        {
            return LocationServices.GetLocations_ListLocation();
        }

        [Route("UpdateLocation")]
        [HttpPut]
        public string UpdateLocation(Location location)
        {
            if (LocationServices.UpdateLocation_String(location).ToLower() == "Successful".ToLower())
            {
                return "Successfully Updated!";
            }
            else
            {
                return LocationServices.UpdateLocation_String(location); 
            }
        }

        [Route("DeleteLocation/{locationid}")]
        [HttpDelete("{locationid}")]
        public string DeleteLocation(int locationid)
        {
            if (LocationServices.DeleteLocationByID_String(locationid).ToLower() == "Successful".ToLower())
            {
                return "Successfully Deleted!";
            }
            else
            {
                return LocationServices.DeleteLocationByID_String(locationid);
            }
        }
    }
}
