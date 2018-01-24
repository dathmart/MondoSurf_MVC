namespace MondoSurf_MVC._5.Controllers
{
    /* 
     * Sample Response from http://api.spitcast.com/api/spot/forecast/238
     * 
     {
        date: "Tuesday Jan 23 2018",
        day: "Tue",
        gmt: "2018-1-23 8",
        hour: "12AM",
        latitude: 33.20422852759,
        live: 1,
        longitude: -117.3959770213895,
        shape: "f",
        shape_detail: {
            swell: "Fair",
            tide: "Poor-Fair",
            wind: "Fair"
        },
        shape_full: "Fair",
        size: 4,
        size_ft: 3.6748718796435957,
        spot_id: 238,
        spot_name: "Oceanside Harbor",
        warnings: [ ]
}
         
    */

    internal class SpitcastAPIResponse
    {
        public string gmt { get; set; }
        public string date { get; set; }
        public string hour { get; set; }
        public int spot_id { get; set; }
        public string spot_name { get; set; }
        public string shape_full { get; set; }
        public class shapeDetail
        {
            public string swell { get; set; }
            public string tide { get; set; }
            public string wind { get; set; }
        }
        public shapeDetail shape_detail { get; set; }
        public double size_ft { get; set; }

    }
}