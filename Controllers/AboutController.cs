using Microsoft.AspNetCore.Mvc;

namespace ShipBase.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Team() { return View(); }
        public ActionResult FAQ() { return View(); }
        public ActionResult TOS() { return View(); }
        public ActionResult Details () { return View(); }
        public ActionResult About() { return View(); }
        public ActionResult Contact() { return View(); }
        public ActionResult Background() { return View(); }
    }
}
