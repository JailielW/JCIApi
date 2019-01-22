using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApI.Models.ContractModels
{
    interface IContract : iID
    {
        string ContractName { get; set; }
        string StateName { get; set; }
    }
}
