
using WebApI.Models.LocationModels;

namespace WebApI.Models.RouteModels
{
    public class Route : IRoute
    {
        protected int routeID;
        public int ID
        {
            get { return routeID; }
            set { routeID = value; }
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

        public Route(int routeid,string pickuptime,string pickuplocationname,
            Status status,string pickupaddress = "",string dropoffaddress = "",
            string dropofftime = "",string dropofflocationname = "")
        {
            routeID = routeid;
            pickupTime = pickuptime;
            dropoffTime = dropofftime;
            pickupLocation.LocationName = pickuplocationname;
            pickupLocation.Address = pickupaddress;
            dropoffLocation.LocationName = dropofflocationname;
            dropoffLocation.Address = dropoffaddress;
            this.status = status;
        }

        public Route(int routeid, string pickuptime, string pickuplocationname,
            int status, string pickupaddress = "", string dropoffaddress = "",
            string dropofftime = "", string dropofflocationname = "")
        {
            routeID = routeid;
            pickupTime = pickuptime;
            dropoffTime = dropofftime;
            pickupLocation.LocationName = pickuplocationname;
            pickupLocation.Address = pickupaddress;
            dropoffLocation.LocationName = dropofflocationname;
            dropoffLocation.Address = dropoffaddress;
            this.status = (Status)status;
        }

        public Route(string pickuptime, string pickuplocationname,
            int status, string pickupaddress = "", string dropoffaddress = "",
            string dropofftime = "", string dropofflocationname = "")
        {
            pickupTime = pickuptime;
            dropoffTime = dropofftime;
            pickupLocation.LocationName = pickuplocationname;
            pickupLocation.Address = pickupaddress;
            dropoffLocation.LocationName = dropofflocationname;
            dropoffLocation.Address = dropoffaddress;
            this.status = (Status)status;
        }

        public Route(string pickuptime, string pickuplocationname,
            Status status, string pickupaddress = "", string dropoffaddress = "",
            string dropofftime = "", string dropofflocationname = "")
        {
            pickupTime = pickuptime;
            dropoffTime = dropofftime;
            pickupLocation.LocationName = pickuplocationname;
            pickupLocation.Address = pickupaddress;
            dropoffLocation.LocationName = dropofflocationname;
            dropoffLocation.Address = dropoffaddress;
            this.status = status;
        }

        public Route()
        {
            routeID = 0;
            pickupTime = "";
            dropoffTime = "";
            pickupLocation.LocationName = "";
            pickupLocation.Address = "";
            dropoffLocation.LocationName = "";
            dropoffLocation.Address = "";
        }
    }
}
