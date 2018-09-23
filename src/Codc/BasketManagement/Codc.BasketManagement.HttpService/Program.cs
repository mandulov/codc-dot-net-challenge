using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Codc.BasketManagement.HttpService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel()
                .Build()
                .Run();
        }
    }
}
