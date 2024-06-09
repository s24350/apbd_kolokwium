using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace WebApplication1.Models
{
    public class Payment
    {
        public int IdPayment { get; set; }

        public DateTime Date { get; set; }

        public int IdClient { get; set; }

        public int IdSubscription { get; set; }

        public SqlMoney Value { get; set; }
        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual Subscription IdSubscriptionNavigation { get; set; } = null!;


    }
}
