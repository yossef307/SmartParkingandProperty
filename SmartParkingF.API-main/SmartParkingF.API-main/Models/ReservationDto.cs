public class ReservationDto
{
    public int PropertyId { get; set; }
    public int ParkingSpotId { get; set; }
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
}