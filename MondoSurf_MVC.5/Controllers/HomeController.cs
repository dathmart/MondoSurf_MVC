using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using mdl = MondoSurf_MVC._5.Models;

namespace MondoSurf_MVC._5.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewData["Title"] = "Mondo Surf";

            var client = new HttpClient();
            var spotId = 238;
            var res = client.GetAsync($"http://api.spitcast.com/api/spot/forecast/{spotId}").Result;
            var resBody = res.Content.ReadAsStringAsync().Result;

            var results = JsonConvert.DeserializeObject<IEnumerable<SpitcastAPIResponse>>(resBody);

            // Save Forecast Data to MondoSurfDBEntities2
            using (var ctx = new mdl.MondoSurfDBEntities2())
            {
                var fcst = new mdl.Spot_Forecast();

                foreach (var p in results)
                {
                    fcst.Spot_Id = p.spot_id;

                    int localDay = DateTime.Parse(p.date).Day;
                    int gmtDay = DateTime.Parse($"{p.gmt}:00:00").Day;


                    int gmtHours = Int32.Parse(p.gmt.Split(new[] { ' ' })[1]);

                    int localHours12 = Int32.Parse(p.hour.Replace("AM", "").Replace("PM", ""));
                    int localHours24 = p.hour.EndsWith("PM")
                                        ? localHours12 + 12
                                        : localHours12 == 12
                                                        ? 0
                                                        : localHours12;
                    var offset = (localDay < gmtDay
                                ? gmtHours + 24
                                : gmtHours) - localHours24;
                    string sign = offset > 0 ? "+" : "";
                    string time = $"{p.gmt}:00:00 {sign}{offset}";
                    fcst.TimeStampGMT = DateTimeOffset.Parse(time);

                    fcst.Size_ft = p.size_ft;
                    fcst.Shape_Full = p.shape_full;
                    fcst.Shape_Detail_Swell = p.shape_detail.swell;
                    fcst.Shape_Detail_Tide = p.shape_detail.tide;
                    fcst.Shape_Detail_Wind = p.shape_detail.wind;
                    ctx.Spot_Forecast.Add(fcst);
                    ctx.SaveChanges();

                }

                //var dtl = new mdl.Spot_Details();
                //    if (dtl.Spot_Id != spotId)
                //    {
                //    dtl.Spot_Id = spotId;
                //    dtl.Spot_Name = "Oceanside Harbor";
                //    ctx.Spot_Details.Add(dtl);
                //    ctx.SaveChanges();
                //    }

            }

            ViewData["SurfData"] = resBody;


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Just ride the Wave, don't be afraid...";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Contact";

            return View();
        }
        public ActionResult SurfLore()
        {
            ViewData["Message"] = "Surf Lore";

            return View();
        }
        public ActionResult SurfRadar()
        {
            ViewData["Message"] = "Surf Radar";

            return View();
        }

    }
}