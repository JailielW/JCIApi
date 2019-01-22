using DBServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApI.Models;
using WebApI.Models.ContractModels;
using System.IO.Compression;

namespace WebApI.DBServices
{
    public static class ContractServices
    {
        private static DBConnectionServices dbconn;
        
        public static string CreateContract_String(Contract contract)
        {
            
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("InsertContract");
            dbconn.AddParameterToList("contractname", SqlDbType.Text, contract.ContractName);
            dbconn.AddParameterToList("statename", SqlDbType.Text, contract.StateName);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }

        public static Contract GetContractByID_Contract(int contractID)
        {
            Contract newContract = new Contract();

            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("GetContractByID");
            dbconn.AddParameterToList("ContractID", SqlDbType.Int, contractID);
            dbconn.SetSqlParameters();

            foreach (DataRow contractDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
            {
                newContract = new Contract(contractID, contractDR["ContractName"].ToString(), 
                    contractDR["StateName"].ToString());
            }

            return newContract;
        }

        public static List<Contract> GetContracts_ListContract()
        {
            List<Contract> ContractList = new List<Contract>();
            Contract newContract = new Contract();

            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("GetContracts");

            foreach (DataRow contractDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
            {
                newContract = new Contract((int)contractDR["ContractID"], contractDR["ContractName"].ToString());

                ContractList.Add(newContract);
            }

            return ContractList;
        }

        public static string UpdateContract_String(Contract contract)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("UpdateContract");

            dbconn.AddParameterToList("contractid", SqlDbType.Int, contract.ID);
            dbconn.AddParameterToList("contractname", SqlDbType.Text, contract.ContractName);
            dbconn.AddParameterToList("statename", SqlDbType.Text, contract.StateName);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }

        //public static Contract UpdateContract_Contract(Contract contract)
        //{
        //    Contract updatedContract = new Contract();

        //    dbconn = new DBConnectionServices("JCIConnection");
        //    dbconn.SetSqlCommandStoredProcedure("UpdateContract");

        //    dbconn.AddParameterToList("contractid", SqlDbType.Int, contract.ID);
        //    dbconn.AddParameterToList("contractname", SqlDbType.Text, contract.ContractName);
        //    dbconn.AddParameterToList("statename", SqlDbType.Text, contract.StateName);

        //    dbconn.SetSqlParameters();

        //    foreach (DataRow contractDR in dbconn.ExecuteStoredProcedureDataTable().Rows)
        //    {
        //        updatedContract = new Contract((int)contractDR["ContractID"], contractDR["ContractName"].ToString(),
        //           (int)contractDR["StateID"]);
        //    }

        //    return updatedContract;
        //}

        public static string DeleteContractByID_String(int contractid)
        {
            dbconn = new DBConnectionServices("JCIConnection");
            dbconn.SetSqlCommandStoredProcedure("DeleteContract");
            dbconn.AddParameterToList("ContractID", SqlDbType.Int, contractid);

            dbconn.SetSqlParameters();
            return dbconn.ExecuteStoredProcedureString();
        }
    }
}
