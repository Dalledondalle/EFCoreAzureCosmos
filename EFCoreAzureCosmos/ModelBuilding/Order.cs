using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreAzureCosmos.ModelBuilding
{
    public class Order
    {
        public int Id { get; set; }
        public int? TrackingNumber { get; set; }
        public string PartitionKey { get; set; }
        public StreetAddress ShippingAddress { get; set; }
    }
}
