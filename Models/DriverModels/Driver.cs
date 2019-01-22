using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBServices;

namespace WebApI.Models.DriverModels
{
    public class Driver : IDriver
    {
        protected int driverID;
        public int ID
        {
            get { return driverID; }
            set { driverID = value; }
        }

        protected string firstname;
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        protected string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FullName
        {
            get { return firstname + " " + lastName; }
        }

        protected string startdate;
        public string StartDate
        {
            get { return startdate; }
            set { startdate = value; }
        }

        protected string enddate;
        public string EndDate
        {
            get { return enddate; }
            set { enddate = value; }
        }

        protected string badgenumber;
        public string BadgeNumber
        {
            get { return badgenumber; }
            set { badgenumber = value; }
        }

        public Driver(int id, string firstName, string lastname, string badgenumber,
            string startdate = null,string enddate = null)
        {
             driverID = id;
             firstname = firstName;
             LastName = lastname;
             StartDate = startdate;
             EndDate = enddate;
             BadgeNumber = badgenumber;
        }

        public Driver(string firstName, string lastname, string badgenumber,
            string startdate = null, string enddate = null)
        {
             firstname = firstName;
             LastName = lastname;
             StartDate = startdate;
             EndDate = enddate;
             BadgeNumber = badgenumber;
        }

        public Driver()
        {
            driverID = 0;
            firstname = "";
            LastName = "";
            StartDate = "";
            EndDate = "";
            BadgeNumber = "";
        }
    }
}
