using System;
using System.ComponentModel.DataAnnotations;

namespace SmartParkingF.API.Models
{
    public class SystemSettings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProjectName { get; set; } = "RealPark Pro";

        [Required]
        [EmailAddress]
        public string SupportEmail { get; set; } = "admin@realstate.com";

        public bool IsMaintenanceMode { get; set; } = false;

        public string BookingPermissions { get; set; } = "Active";

        public string? ApiSecurityKey { get; set; }

        public DateTime LastBackupDate { get; set; } = DateTime.Now;
    }
}