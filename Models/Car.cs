namespace CarRentalApp.Models
{
    public class Car
    {
            public int Id { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public decimal PricePerDay { get; set; }
            public List<string> ImageUrls { get; set; }
        
    }
}
