namespace SmartParkingF.API.Models // تم التعديل للاسم الفعلي للمشروع
{
    public class ParkingStatsDto
    {
        public int TotalSpots { get; set; }
        public int OccupiedSpots { get; set; }
        public int AvailableSpots { get; set; }

        // خاصية محسوبة لنسبة الإشغال (Read-only) لضمان دقة البيانات
        public double OccupancyRate
        {
            get
            {
                if (TotalSpots == 0) return 0;
                // حساب النسبة المئوية: (المشغول / الإجمالي) * 100
                return Math.Round((double)OccupiedSpots / TotalSpots * 100, 2);
            }
        }
    }
}