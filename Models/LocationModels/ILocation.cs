namespace WebApI.Models.LocationModels
{
    interface ILocation : iID
    {
         string LocationName { get; set; }
         string Address { get; set; }
    }
}
