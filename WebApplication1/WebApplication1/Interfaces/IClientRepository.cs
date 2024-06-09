using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;

namespace WebApplication1.Interfaces
{
    public interface IClientRepository
    {
        public Task<IActionResult> GetClientData(int IdClient);

        public Task<int> AddSubscriptionInfo(PaymentDTO payment);
    }
}
