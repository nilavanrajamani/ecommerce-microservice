using AspnetRun.Services.Orders.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Services.Orders.Infrastructure.Data
{
    public class AspnetRunContextSeed
    {
        public static async Task SeedAsync(AspnetRunContext aspnetrunContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {

                // cart and cart items - order and order items
                await SeedOrderAndItemsAsync(aspnetrunContext);                
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AspnetRunContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(aspnetrunContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }                
        private static async Task SeedOrderAndItemsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Orders.Any())
                return;

            var address = new Address
            {
                AddressLine = "Gungoren",
                City = "Istanbul",
                Country = "Turkey",
                EmailAddress = "aspnetrun@outlook.com",
                FirstName = "Mehmet",
                LastName = "Ozkaya",
                CompanyName = "AspnetRun",
                PhoneNo = "05012222222",
                State = "027",
                ZipCode = "34056"
            };

            var addressShipping = new Address
            {
                AddressLine = "Gungoren",
                City = "Istanbul",
                Country = "Turkey",
                EmailAddress = "aspnetrun@outlook.com",
                FirstName = "Mehmet",
                LastName = "Ozkaya",
                CompanyName = "AspnetRun",
                PhoneNo = "05012222222",
                State = "027",
                ZipCode = "34056"
            };

            var orders = new List<Order>()
            {
                new Order
                {
                    UserName = "mehmetozkaya@gmail.com",
                    //BillingAddress = address,
                    //ShippingAddress = addressShipping,
                    PaymentMethod = PaymentMethod.Cash,
                    Status = OrderStatus.Progress,
                    GrandTotal = 347,
                    Items = new List<OrderItem>
                    {
                       new OrderItem
                       {
                           Product = aspnetrunContext.Products.FirstOrDefault(p => p.Name == "uPhone X"),
                            Quantity = 2,
                            Color = "Black",
                            UnitPrice = 295,
                            TotalPrice = 590
                       },
                        new OrderItem
                        {
                            Product = aspnetrunContext.Products.FirstOrDefault(p => p.Name == "Game Station X 22"),
                            Quantity = 1,
                            Color = "Red",
                            UnitPrice = 295,
                            TotalPrice = 295
                        },
                        new OrderItem
                        {
                            Product = aspnetrunContext.Products.FirstOrDefault(p => p.Name == "Jackson Toster V 27"),
                            Quantity = 1,
                            Color = "Black",
                            UnitPrice = 185,
                            TotalPrice = 185
                        }
                    }
                }
            };

            aspnetrunContext.Orders.AddRange(orders);
            await aspnetrunContext.SaveChangesAsync();
        }
        
    }
}
