using BlazingShop.Shared;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;
using System.Collections.Generic;

namespace BlazingShop.Server.Services
{
    public class PaymentService : IPaymentService
    {
        public PaymentService(IConfiguration config)
        {
            StripeConfiguration.ApiKey = config.GetSection("StripeId").Value;
        }

        public Session CreateCheckoutSession(List<CartItem> cartItems)
        {
            var lineItems = new List<SessionLineItemOptions>();
            cartItems.ForEach(ci => lineItems.Add(new SessionLineItemOptions()
            {
                PriceData = new SessionLineItemPriceDataOptions()
                {
                    UnitAmountDecimal = ci.Price * 100,
                    Currency = "eur",
                    ProductData = new SessionLineItemPriceDataProductDataOptions()
                    {
                        Name = ci.ProductTitle,
                        Images = new List<string>() { ci.Image }
                    },

                },

                Quantity = ci.Quantity

            }));
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:5001/order-success",
                CancelUrl = "https://localhost:5001/cart"
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return session;
        }
    
    }
    
}
