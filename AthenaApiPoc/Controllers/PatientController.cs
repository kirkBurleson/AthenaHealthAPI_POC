using System.Web.Mvc;
using ViewModels;
using Services;
using Interfaces;

namespace AthenaApiPoc.Controllers
{
    public class PatientController : Controller
    {
		 IAthenaService athena;

		public PatientController()
		{
            // TODO: Use a DI container for this
            athena = new PatientService(new APIConnection());
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult CreatePatient()
        {
			return View(new CreatePatientVM());
		}

		[HttpPost]
		public ActionResult CreatePatient(CreatePatientVM model)
		{
			return View(athena.Create(model));
		}

		public ActionResult SearchForPatient()
		{
			return View(new SearchForPatientVM());
		}

		[HttpPost]
		public ActionResult SearchForPatient(SearchForPatientVM model)
		{
			return View(athena.Search(model));
		}

		public ActionResult UpdatePatient()
		{
			return View(new UpdatePatientVM());
		}

		[HttpPost]
		public ActionResult UpdatePatient(UpdatePatientVM model)
		{
			if (model.Id == null)
			{
				 return RedirectToAction("Update");
			}
			else
			{
				return View(athena.Update(model));
			}
		}

	}
}