using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAzureCosmos.ModelBuilding
{
    public static class Sample
    {
        public static async Task Run()
        {
            using (var context = new OrderContext())
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();

                context.Add(
                    new Order
                    {
                        Id = 1,
                        ShippingAddress = new StreetAddress { City = "London", Street = "221 B Baker St" },
                        PartitionKey = "1"
                    });

                await context.SaveChangesAsync();
            }
        }
    }
}
