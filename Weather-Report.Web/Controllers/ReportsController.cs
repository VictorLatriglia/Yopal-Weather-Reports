using Microsoft.AspNetCore.Mvc;
using Weather_Report.Models.ViewModels;
using Weather_Report.ServiceContracts;

namespace Weather_Report.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        readonly IReportsService _reportsService;
        readonly IStationsService _stationsService;

        public ReportsController(
            IReportsService reportsService,
            IStationsService stationsService)
        {
            _reportsService = reportsService;
            _stationsService = stationsService;
        }

        [HttpPost("AddReport")]
        public async Task<IActionResult> StationReport(StationReport report)
        {
            var result = await _reportsService.AddReport(report);
            return Ok(result.Id);
        }

        [HttpPost("AddStation")]
        public async Task<IActionResult> AddStation(StationVm station)
        {
            var result = await _stationsService.AddStation(station);
            return Ok(result.Id);
        }

        [HttpGet("GetReports")]
        public async Task<IActionResult> GetReports()
        {
            var result = await _stationsService.GetStationsWithReports(false);
            return Ok(result);
        }
    }
}
