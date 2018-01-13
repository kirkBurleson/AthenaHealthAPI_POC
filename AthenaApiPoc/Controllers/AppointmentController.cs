using System.Web.Mvc;
using ViewModels;
using Interfaces;
using Services;
using TransferModels;
using Mapping;

namespace AthenaApiPoc.Controllers
{
	public class AppointmentController : Controller
	{
		private IAthenaService apptService;
		private IAthenaService providerService;

		public AppointmentController()
		{
			apptService = new AppointmentService();
			providerService = new ProviderService();
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult BookAppointmentsFromFile()
		{
			var vm = new CreateAppointmentVM();

			// read file
			/*
			var filename = "AthenaTest.csv";
			if (System.IO.File.Exists(filename) == false)
			{
				return View(new BookAppointmentsFromFileVM { NumFilesProcessed = "0" } );
			}
			else
			{
				using (System.IO.StreamReader reader = System.IO.File.OpenText(filename))
				{
					string header = reader.ReadLine();
					string line = null;
					do
					{
						line = reader.ReadLine();
					} while (line != null);
				}
			}
			*/


			// loop, booking each appointment

			// return status msg in view
			return View();
		}

		public ActionResult CreateAppointment()
		{
			var vm = new CreateAppointmentVM();
			var input = new ProviderSearchInput();
			var providers = providerService.Search(input);

			vm.ProviderIDs = ProviderMapper.MapProviderSearchResult_ProviderIds(providers);

			return View(vm);
		}

		[HttpPost]
		public ActionResult CreateAppointment(CreateAppointmentVM vm)
		{
			return View(apptService.Create(vm));
		}

	}
}