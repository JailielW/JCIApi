using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApI.Models.LocationModels;

namespace WebApI.Models.RouteModels
{
    interface IRoute : iID
    {
         string PickUpTime { get; set; }
         string DropOffTime { get; set; }
         Location PickUpLocation { get; set; }
         Location DropOffLocation { get; set; }
         Status Status { get; set; }
    }
}
