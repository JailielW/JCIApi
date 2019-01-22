
namespace WebApI.Models.LocationModels
{
    public class Location : ILocation
    {
        protected int locationID;
        public int ID
        {
            get { return locationID; }
            set { locationID = value; }
        }
        protected string locationName;
        public string LocationName
        {
            get { return locationname; }
            set { locationname = value; }
        }
        protected string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Location(int locationid,string locationname,string address)
        {
            locationID = locationid;
            locationName = locationname;
            this.address = address;
        }

        public Location(string locationname, string address)
        {
            locationName = locationname;
            this.address = address;
        }

        public Location()
        {
            locationID = 0;
            locationName = "";
            address = "";
        }
    }
}
