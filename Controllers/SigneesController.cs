using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApI.DBServices;
using WebApI.Models;
using WebApI.Models.SigneeModels;

namespace WebApI.Controllers
{
    [Route("[controller]")]
    public class SigneesController : ControllerBase
    {
        [Route("CreateSignee")]
        [HttpPut]
        public string CreateSignee(Signee signee)
        {
            if (SigneeServices.CreateSignee_String(signee).ToLower() == "Successful".ToLower())
            {
                return "Successfully Created!";
            }
            else
            {
                return SigneeServices.CreateSignee_String(signee);
            }
        }

        [Route("GetSignee/{id}")]
        [HttpGet]
        public Signee GetSignee(int id)
        {
            return SigneeServices.GetSigneeByID_Signee(id);
        }

        [Route("GetSignees")]
        [HttpGet]
        public List<Signee> GetSignees()
        {
            return SigneeServices.GetSignees_ListSignee();
        }
        
        [Route("UpdateSignee")]
        [HttpPut]
        public string UpdateSignee(Signee signee)
        {
            if (SigneeServices.UpdateSignee_String(signee).ToLower() == "Successful".ToLower())
            {
                return "Successfully Updated!";
            }
            else
            {
                return SigneeServices.UpdateSignee_String(signee);
            }
        }

        [Route("DeleteSignee/{id}")]
        [HttpDelete("{id}")]
        public string DeleteSignee(int id)
        {
            if (SigneeServices.DeleteSigneeByID_String(id).ToLower() == "Successful".ToLower())
            {
                return "Successfully Updated!";
            }
            else
            {
                return SigneeServices.DeleteSigneeByID_String(id);
            }
        }
    }
}
