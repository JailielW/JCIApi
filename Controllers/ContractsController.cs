using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApI.DBServices;
using WebApI.Models;
using WebApI.Models.ContractModels;

namespace WebApI.Controllers
{
    [Route("[controller]")]
    public class ContractsController : ControllerBase
    {
        
        
        [Route("GetContract/{id}")]
        [HttpGet]
        public Contract GetContractByID(int id)
        {
            return ContractServices.GetContractByID_Contract(id);
        }

        [Route("GetContracts")]
        [HttpGet]
        public List<Contract> GetContracts()
        {
            return ContractServices.GetContracts_ListContract();
        }

        [Route("CreateContract")]
        [HttpPut]
        public string CreateContract(Contract contract)
        {
            if (ContractServices.CreateContract_String(contract).ToLower() == "Successful".ToLower())
            {
                return "Successfully Created!";
            }
            else
            {
                return ContractServices.CreateContract_String(contract);
            }
        }

        [Route("UpdateContract")]
        [HttpPut]
        public string UpdateContract(Contract contract)
        {
            if (ContractServices.UpdateContract_String(contract).ToLower() == "Successful".ToLower())
            {
                return "Succesfully Updated!";
            }
            else
            {
                return ContractServices.UpdateContract_String(contract); ;
            }
        }

        [Route("DeleteContract/{id}")]
        [HttpDelete("{id}")]
        public string DeleteContract(int id)
        {
            if(ContractServices.DeleteContractByID_String(id).ToLower() == "Successful".ToLower())
            {
                return "Successfully Deleted!";
            }
            else
            {
                return ContractServices.DeleteContractByID_String(id);
            }
        }
    }
}
