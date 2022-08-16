using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Report.Models;
using Weather_Report.Models.ViewModels;

namespace Weather_Report.ServiceContracts
{
    public interface IReportsService
    {
        Task<Report> AddReport(StationReport report);
    }
}
