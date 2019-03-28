using System.Web.Mvc;

namespace TDD_Practices.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View("~/Views/Home/Index.cshtml");
    }

    // GET: Home
    public ActionResult Get()
    {
        return View("~/Views/Home/Index.cshtml");
    }
  }
}
