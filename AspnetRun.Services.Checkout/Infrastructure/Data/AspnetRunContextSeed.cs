using AspnetRun.Services.Basket.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Services.Basket.Infrastructure.Data
{
    public class AspnetRunContextSeed
    {
        public static async Task SeedAsync(AspnetRunContext aspnetrunContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // NOTE : Only run this if using a real database
                // aspnetrunContext.Database.Migrate();
                // aspnetrunContext.Database.EnsureCreated();

                // categories - specifications - reviews - tags
                await SeedCategoriesAsync(aspnetrunContext);
                await SeedProductsAsync(aspnetrunContext);
                await SeedCartAndItemsAsync(aspnetrunContext);                
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

        private static async Task SeedCategoriesAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Categories.Any())
                return;

            var categories = new List<Category>()
            {
                new Category() { Name = "Laptop"}, // 1
                new Category() { Name = "Drone"}, // 2
                new Category() { Name = "TV & Audio"}, // 3
                new Category() { Name = "Phone & Tablet"}, // 4
                new Category() { Name = "Camera & Printer"}, // 5
                new Category() { Name = "Games"}, // 6
                new Category() { Name = "Accessories"}, // 7
                new Category() { Name = "Watch"}, // 8
                new Category() { Name = "Home & Kitchen Appliances"} // 9
            };

            aspnetrunContext.Categories.AddRange(categories);
            await aspnetrunContext.SaveChangesAsync();
        }

        private static async Task SeedProductsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Products.Any())
                return;

            var products = new List<Product>
            {
                // Phone
                new Product()
                {
                    Name = "uPhone X",
                    Category = aspnetrunContext.Categories.FirstOrDefault(c => c.Name == "Phone & Tablet"),
                },
                new Product()
                {
                    Name = "Ornet Note 9",
                    CategoryId = 4,
                },
                new Product()
                {
                    Name = "Sany Experia Z5",
                    CategoryId = 4,
                },
                new Product()
                {
                    Name = "Flex P 3310",
                    CategoryId = 4,
                },
                // Camera                
                new Product()
                {
                    Name = "Mony Handycam Z 105",
                    CategoryId = 5,
                },
                new Product()
                {
                    Name = "Axor Digital Camera",
                    CategoryId = 5,
                },
                new Product()
                {
                    Name = "Silvex DSLR Camera T 32",
                    CategoryId = 5,
                },
                new Product()
                {
                    Name = "Necta Instant Camera",
                    CategoryId = 5,
                },
                // Printer
                new Product()
                {
                    Name = "Pranon Photo Printer Y 25",
                    CategoryId = 5,
                },
                // Game                
                new Product()
                {
                    Name = "Game Station X 22",
                    CategoryId = 6,
                },
                new Product()
                {
                    Name = "Game Stations PW 25",
                    CategoryId = 6,
                },
                // Laptop      
                new Product()
                {
                    Name = "Zeon Zen 4 Pro",
                    CategoryId = 1,
                },
                // Drone                
                new Product()
                {
                    Name = "Aquet Drone D 420",
                    CategoryId = 2,
                },
                // Accessories
                new Product()
                {
                    Name = "Roxxe Headphone Z 75",
                    CategoryId = 7,
                },
                // Watch
                new Product()
                {
                    Name = "Mascut Smart Watch",
                    CategoryId = 8,
                },
                new Product()
                {
                    Name = "Z Bluetooth Headphone",
                    CategoryId = 8,
                },
                // TV & Audio
                new Product()
                {
                    Name = "Roses Speaker Box",
                    CategoryId = 3,
                },
                new Product()
                {
                    Name = "Nexo Andriod TV Box",
                    CategoryId = 3,
                },
                new Product()
                {
                    Name = "Xonet Speaker P 9",
                    CategoryId = 3,
                },
                // Home & Kitchen Appliances
                new Product()
                {
                    Name = "Zorex Coffe Maker",
                    CategoryId = 9,
                },
                new Product()
                {
                    Name = "Jeilips Steam Iron K 2",
                    CategoryId = 9,
                },
                new Product()
                {
                    Name = "Jackson Toster V 27",
                    CategoryId = 9,
                },
                new Product()
                {
                    Name = "Mega Juice Maker",
                    CategoryId = 9,
                },
                new Product()
                {
                    Name = "Shine Microwave Oven",
                    CategoryId = 9,
                },
                new Product()
                {
                    Name = "Auto Rice Cooker",
                    CategoryId = 9,
                }
            };

            aspnetrunContext.Products.AddRange(products);
            await aspnetrunContext.SaveChangesAsync();
        }

        private static async Task SeedCartAndItemsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Carts.Any())
                return;

            var carts = new List<Cart>()
            {
                new Cart
                {
                    UserName = "mehmetozkaya@gmail.com",
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Product = aspnetrunContext.Products.FirstOrDefault(p => p.Name == "uPhone X"),
                            Quantity = 2,
                            Color = "Black",
                            UnitPrice = 295,
                            TotalPrice = 590
                        },
                        new CartItem
                        {
                            Product = aspnetrunContext.Products.FirstOrDefault(p => p.Name == "Game Station X 22"),
                            Quantity = 1,
                            Color = "Red",
                            UnitPrice = 295,
                            TotalPrice = 295
                        },
                        new CartItem
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

            aspnetrunContext.Carts.AddRange(carts);
            await aspnetrunContext.SaveChangesAsync();
        }        
    }
}
