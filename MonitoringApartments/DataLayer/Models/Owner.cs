namespace DataLayer.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string OwnerNameSurname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string SecureQuestion1 { get; set; }
        public string SecureQuestion2 { get; set; }
    }
}