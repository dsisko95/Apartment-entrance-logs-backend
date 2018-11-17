namespace DataLayer.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public int City_id { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string OwnerNameSurname { get; set; }
        public string CityName { get; set; }
        public int Number { get; set; }
        public int OwnerId { get; set; }
    }
}