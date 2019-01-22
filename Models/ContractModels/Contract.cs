using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApI.Models.ContractModels
{
    public class Contract : IContract
    {
        protected int contractID;
        public int ID
        {
            get { return contractID; }
            set { contractID = value; }
        }

        protected string contractName;
        public string ContractName
        {
            get { return contractName; }
            set { contractName = value; }
        }

        protected string stateName;
        public string StateName
        {
            get { return stateName; }
            set { stateName = value; }
        }

        public Contract(int contractid,string contractname,string statename)
        {
            this.contractID = contractid;
            this.contractName = contractname;
            this.stateName = statename;
        }

        public Contract(int contractid, string contractname)
        {
            this.contractID = contractid;
            this.contractName = contractname;
        }

        public Contract(string contractname, string statename)
        {
            this.contractName = contractname;
            this.stateName = statename;
        }

        public Contract()
        {
            ID = 0;
            contractName = "";
            stateName = "";
        }
    }
}
