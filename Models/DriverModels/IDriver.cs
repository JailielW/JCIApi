using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApI.Models.DriverModels
{
    interface IDriver : iID, iFullName
    {
         string StartDate { get; set; }
         string EndDate { get; set; }
         string BadgeNumber { get; set; }
    }
}
