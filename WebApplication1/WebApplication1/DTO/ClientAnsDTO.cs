namespace WebApplication1.DTO
{
    public class ClientAnsDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EMail { get; set; }

        public string Phone { get; set; }

        public int Discount { get; set; }

        public List<SubscriptionAnsDTO> Subscriptions = new List<SubscriptionAnsDTO>();
    }
}
