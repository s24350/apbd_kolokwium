using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Interfaces;
using WebApplication1.Context;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.ComponentModel.DataAnnotations;
using WebApplication1.DTO;
using System.Reflection.Metadata.Ecma335;

namespace WebApplication1.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApbdContext _context;

        public ClientRepository(ApbdContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetClientData(int IdClient)
        {
            var wantedClient = await _context.Clients.FirstOrDefaultAsync(e => e.IdClient == IdClient);

            var wantedDiscount = await _context.Discounts.FirstOrDefaultAsync(e => e.IdDiscount == IdClient);
            
            var sales = await _context.Sales.ToListAsync();

            List<SubscriptionAnsDTO> wantedSubscriptions = new List<SubscriptionAnsDTO>();

            foreach (var item in sales)
            {
                var wantedSub = await _context.Subscriptions.FirstOrDefaultAsync(e => e.IdSubscription == item.IdSubscription);
                wantedSubscriptions.Add(new SubscriptionAnsDTO {
                    IdSubscription = item.IdSubscription,
                    Name = wantedSub.Name,
                    Renewal = wantedSub.Renewal,
                });
            }
            

            var result = await _context
                .Clients
                .Select(e=>
                new ClientAnsDTO {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    EMail = e.EMail,
                    Phone = e.Phone,
                    Discount = wantedDiscount.Value,
                    Subscriptions = wantedSubscriptions,
                 
                }).ToListAsync();

            return (IActionResult)result;
        }

        public async Task<int> AddSubscriptionInfo(PaymentDTO payment)
        {
            bool clientExists = await _context.Clients.AnyAsync(e=> e.IdClient==payment.IdClient);
            if (!clientExists) {
                return 1;
            }

            bool SubscriptionExists = await _context.Subscriptions.AnyAsync(e => e.IdSubscription == payment.IdSubscription);

            if (!SubscriptionExists)
            {
                return 1;
            }

            bool SubscriptionActive = await _context.Subscriptions.AnyAsync(e => e.EndTime > DateTime.Now);
            if (!SubscriptionActive)
            {
                return 2;
            }

            var PaymentToAdd = new Payment
            {
                Date = DateTime.Now,
                IdClient = payment.IdClient,
                IdSubscription = payment.IdSubscription,
                Value = payment.Value
            };

            return 0;
        }
    }
}
