using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsyncLab.MVC.Controllers
{
    //http://www.tuicool.com/articles/zUraa2
    public class HomeController : AsyncController
    {
        public async Task<ActionResult> Index()
        {
            await Task.Delay(1100);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}