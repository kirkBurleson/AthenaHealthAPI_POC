using System.Web.Mvc;

namespace AthenaApiPoc.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}