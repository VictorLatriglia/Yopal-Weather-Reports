namespace Weather_Report.Models.ViewModels
{
    public class StationReport
    {
        public string StationId { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double Pluviometry { get; set; }
        public double Luminosity { get; set; }
    }
}
