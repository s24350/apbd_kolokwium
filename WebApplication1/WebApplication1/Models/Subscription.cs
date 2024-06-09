using System.Data.SqlTypes;

namespace WebApplication1.Models
{
    public class Subscription
    {
        public int IdSubscription { get; set; }

        public string Name { get; set; }

        public int Renewal { get; set; }

        public DateTime EndTime { get; set; }

        public SqlMoney Price { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
    }
}
