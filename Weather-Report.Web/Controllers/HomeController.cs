using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Weather_Report.ServiceContracts;
using Weather_Report.Web.Models;

namespace Weather_Report.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStationsService _stationsService;

        public HomeController(
            ILogger<HomeController> logger,
            IStationsService stationsService)
        {
            _logger = logger;
            _stationsService = stationsService;
        }

        public async Task<IActionResult> Index()
        {
            var stations = await _stationsService.GetStationsWithReports(true);
            List<StationsReport> model = stations?.Select(x =>
            new StationsReport
            {
                lat = x.Latitude,
                lng = x.Longitude,
                Humidity = x.Reports.LastOrDefault()?.Humidity ?? 0,
                Temperature = x.Reports.LastOrDefault()?.Temperature ?? 0,
                ReportTime = x.Reports.LastOrDefault()?.CreatedOn ?? new DateTime()
            }).ToList() ?? new List<StationsReport>();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}