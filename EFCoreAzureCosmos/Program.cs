using EFCoreAzureCosmos.ModelBuilding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EFCoreAzureCosmos
{    
    class Program
    {
        static async Task Main(string[] args)
        {
            await Sample.Run();
            await UnstructuredData.Sample.Run();
        }
    }
}
