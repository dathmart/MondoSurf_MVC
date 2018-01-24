using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mdl = MondoSurf_MVC._5.Models;

namespace MondoSurf_MVC._5.Common
{
    public class ErrorLogHandler
    {
        public void WriteLog(Exception ex, String url = "" )
        {
            using (var ctx = new mdl.MondoSurfDBEntities2())
            {
                var log = new mdl.Error();

            }
        }
    }
}