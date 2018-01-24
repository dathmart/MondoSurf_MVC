using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MondoSurf_MVC._5.Controllers
{
    public class CustomErrorController : Controller
    {
        // GET: CustomError
        [HandleError]
        public ActionResult Index()
        {
            return View();
        }
    }
}