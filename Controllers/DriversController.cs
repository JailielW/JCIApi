using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApI.DBServices;
using WebApI.Models;
using WebApI.Models.DriverModels;

namespace WebApI.Controllers
{
    [Route("[controller]")]
    public class DriversController : ControllerBase
    {
        [Route("GetDriver/{id}")]
        [HttpGet]
        public Driver GetDriver(int id)
        {
            return DriverServices.GetDriverByID_Driver(id);
        }

        [Route("GetDrivers")]
        [HttpGet]
        public List<Driver> GetDrivers()
        {
            return DriverServices.GetDrivers_ListDriver();
        }

        [Route("CreateDriver")]
        [HttpPut]
        public string CreateDriver(Driver driver)
        {
            if (DriverServices.CreateDriver_String(driver).ToLower() == "Successful".ToLower())
            {
                return "Successfully Created!";
            }
            else
            {
                return DriverServices.CreateDriver_String(driver);
            }
        }

        [Route("UpdateDriver")]
        [HttpPut]
        public string UpdateDriver(Driver driver)
        {
            if (DriverServices.UpdateDriver_String(driver).ToLower() == "Successful".ToLower())
            {
                return "Successfully Updated!";
            }
            else
            {
                return DriverServices.UpdateDriver_String(driver);
            }
        }

        [Route("DeleteDriver/{id}")]
        [HttpDelete("{id}")]
        public string DeleteDriver(int id)
        {
            if (DriverServices.DeleteDriverByID_String(id).ToLower() == "Successful".ToLower())
            {
                return "Successfully Deleted!";
            }
            else
            {
                return DriverServices.DeleteDriverByID_String(id);
            }
        }
    }
}
