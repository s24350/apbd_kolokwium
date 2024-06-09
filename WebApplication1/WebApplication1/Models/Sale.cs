namespace WebApplication1.Models
{
    public class Sale
    {
        public int IdSale { get; set; }
        public DateTime CreatedAt { get; set; }

        public int IdSubscription { get; set; }
        public virtual Subscription IdSubscriptionNavigation { get; set; } = null!;

        public int IdClient { get; set; }
        public virtual Client IdClientNavigation { get; set; } = null!;
    }
}
