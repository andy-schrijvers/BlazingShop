using BlazingShop.Shared;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Server.Services
{
    public interface IPaymentService
    {
        Session CreateCheckoutSession(List<CartItem> cartItems);
    }

    public class PaymentService : IPaymentService
    {
        public PaymentService()
        {
            StripeConfiguration.ApiKey = "sk_test_51JjU4SATGV5VFVw1vjPVFQtPfd1XN4qGxmIb74IEbtsXt8CtEh1LqppEOAa5My5SaNsQcjb99uN9VFJBpZndwVYA00kdzURSiw";
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
