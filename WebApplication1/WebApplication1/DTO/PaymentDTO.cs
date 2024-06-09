using System.Data.SqlTypes;

namespace WebApplication1.DTO
{
    public class PaymentDTO
    {
        public int IdClient { get; set; }

        public int IdSubscription { get; set; }

        public SqlMoney Value { get; set; }
    }
}
