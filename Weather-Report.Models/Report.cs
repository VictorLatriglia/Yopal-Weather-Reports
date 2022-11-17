using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Report.Models
{
    public class Report : EntityBase
    {
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double Pluviometry { get; set; }
        public double Luminosity { get; set; }
        public string StationId { get; set; }
        

    }
}
