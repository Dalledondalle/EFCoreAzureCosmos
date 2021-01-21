using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreAzureCosmos.ModelBuilding
{
    public class Distributor
    {
        public int Id { get; set; }
        public string ETag { get; set; }
        public ICollection<StreetAddress> ShippingCenters { get; set; }
    }
}
