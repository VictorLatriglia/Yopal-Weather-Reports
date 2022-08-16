using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Report.DataAccess.Repository;
using Weather_Report.Models;
using Weather_Report.Models.ViewModels;
using Weather_Report.ServiceContracts;

namespace Weather_Report.Services
{
    public class ReportsService : IReportsService
    {
        readonly IRepository<Report> _reportsRepo;

        public ReportsService(
            IRepository<Report> reportsRepo)
        {
            _reportsRepo = reportsRepo;
        }

        public async Task<Report> AddReport(StationReport report)
        {
            return await _reportsRepo.AddAsync(new Report { Humidity = report.Humidity, StationId = report.StationId, Temperature = report.Temperature });
        }


    }
}
