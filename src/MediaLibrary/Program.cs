using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace MediaLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .ConfigureLogging(f => f.AddConsole(LogLevel.Debug))
                .UseStartup<Startup>()
		        .UseUrls("http://localhost:6001/")
                .Build();

            host.Run();
        }
    }
}
