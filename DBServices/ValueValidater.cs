using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApI.DBServices
{
    public class ValueValidater
    {
        public static object ReturnValue(object value)
        {
            if(value == null)
            {
                return null;
            }
            else
            {
                return value;
            }
        }
    }
}
