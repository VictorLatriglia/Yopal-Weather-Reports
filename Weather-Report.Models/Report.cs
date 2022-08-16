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

        public string StationId { get; set; }
        public virtual Station Station { get; set; }

    }
}
