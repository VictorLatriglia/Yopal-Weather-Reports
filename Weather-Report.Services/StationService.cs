using Microsoft.EntityFrameworkCore;
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
    public class StationService : IStationsService
    {
        readonly IRepository<Station> _stationsRepo;
        readonly IRepository<Report> _reportsRepo;
        public StationService(
            IRepository<Station> stationsRepo,
            IRepository<Report> reportsRepo)
        {
            _stationsRepo = stationsRepo;
            _reportsRepo = reportsRepo;
        }
        public async Task<Station> AddStation(StationVm station)
        {
            return await _stationsRepo.AddAsync(new Station { Latitude = station.Latitude, Longitude = station.Longitude });
        }

        public async Task<IList<Station>> GetStationsWithReports(bool onlyRecentReport)
        {
            var stations = await _stationsRepo.GetAllAsync();
            foreach (var station in stations)
            {
                station.Reports = onlyRecentReport ?
                    new List<Report> { (await _reportsRepo.AsQueryable().OrderByDescending(x => x.CreatedOn).FirstOrDefaultAsync(x => x.StationId == station.Id)) ?? new Report() } :
                    await _reportsRepo.QueryAsync(x => x.StationId == station.Id);
            }
            return stations;
        }
    }
}
