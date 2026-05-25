namespace SmartParkingF.API.Models
{
    public class DashboardStatsDto
    {
        public string UserName { get; set; } = string.Empty;
        public int ActiveReservations { get; set; }
        public decimal TotalPayments { get; set; }
        public int RecentInvoices { get; set; }
        public string CurrentSpot { get; set; } = "None";
        public string GateStatus { get; set; } = "Disabled";
    }
}