using System;

namespace DataLayer.Models
{
    public class Monitoring
    {
        public int Id { get; set; }
        public int Apartment_id { get; set; }
        public string CityName { get; set; }
        public string ApartmentAddress { get; set; }
        public string ApartmentType { get; set; }
        public string OwnerNameSurname { get; set; }
        public string ClientNameSurname { get; set; }
        public string Client_Identification_number { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Telephone { get; set; }
        public int ApartmentNumber { get; set; }
    }
}