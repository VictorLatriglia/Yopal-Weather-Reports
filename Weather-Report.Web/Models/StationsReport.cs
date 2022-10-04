namespace Weather_Report.Web.Models
{
    public class StationsReport
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public DateTime ReportTime { get; set; }
        public string ReportTimeStr { get => ReportTime.ToString("dd-MM-yyyy HH:mm:ss"); }
    }
}
