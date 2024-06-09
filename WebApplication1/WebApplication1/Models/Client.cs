namespace WebApplication1.Models
{
    public class Client
    {

        public int IdClient { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EMail {  get; set; }

        public string Phone { get; set; }
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    }
}
