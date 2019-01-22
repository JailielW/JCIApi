
using WebApI.Models.DriverModels;
using WebApI.Models.LocationModels;
using WebApI.Models.SigneeModels;

namespace WebApI.Models.RouteModels
{
    public class RouteDetail : IRoute
    {
        protected int routeID;
        public int ID
        {
            get { return routeID; }
            set { routeID = value; }
        }

        protected Driver driver;
        public string DriverName
        {
            get { return driver.FullName; }
        }

        protected Signee pickupsignee;
        public Signee PickUpSignee
        {
            get { return pickupsignee; }
            set { pickupsignee = value; }
        }

        protected Signee dropoffsignee;
        public Signee DropOffSignee
        {
            get { return dropoffsignee; }
            set { dropoffsignee = value; }
        }

        protected string pickupTime;
        public string PickUpTime
        {
            get { return pickupTime; }
            set { pickupTime = value; }
        }

        protected string dropoffTime;
        public string DropOffTime
        {
            get { return dropoffTime; }
            set { dropoffTime = value; }
        }

        protected Location pickupLocation;
        public Location PickUpLocation
        {
            get { return pickupLocation; }
            set { pickupLocation = value; }
        }

        protected Location dropoffLocation;
        public Location DropOffLocation
        {
            get { return dropoffLocation; }
            set { dropoffLocation = value; }
        }

        protected Status status;
        public Status Status
        {
            get { return status; }
            set { status = value; }
        }

        public RouteDetail(int routeid,string driverfirstName,string driverlastName,
            string pickuptime,string dropofftime,string pickupsigneefirstname ,string pickupsigneelastname,
            string dropoffsigneefirstname, string dropoffsigneelastname,string PickUpFacility,
            string PickUpAddress ,string DropOffFacility, string DropOffAddress, int status
            )
        {
            routeID = routeid;
            driver.FirstName = driverfirstName;
            driver.LastName = driverlastName;
            pickupTime = pickuptime;
            dropoffTime = dropofftime;
            pickupsignee.FirstName = pickupsigneefirstname;
            pickupsignee.LastName = pickupsigneelastname;
            dropoffsignee.FirstName = dropoffsigneefirstname;
            dropoffsignee.LastName = dropoffsigneelastname;
            pickupLocation.LocationName = PickUpFacility;
            pickupLocation.Address = PickUpAddress;
            dropoffLocation.LocationName = DropOffFacility;
            dropoffLocation.Address = DropOffAddress;
            this.status = (Status)status;
        }
    }
}
