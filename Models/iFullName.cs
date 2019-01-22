using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApI.Models
{
    interface iFullName
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get;}
    }
}
