namespace NobreCharcutaria.ADO.NET.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Address { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string CEP { get; set; }
        public string identificationNumber { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int CustomerTypeId { get; set; }
    }
}
