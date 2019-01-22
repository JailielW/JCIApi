using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApI.Models
{
    public class States : iState
    {
        protected int stateID;
        public int ID
        {
            get { return stateID; }
            set { stateID = value; }
        }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        
    }

    interface iState : iID
    {
    }
}
