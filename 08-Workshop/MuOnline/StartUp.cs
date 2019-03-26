namespace MuOnline
{
    using System;
    using MuOnline.Core;
    using MuOnline.Core.Contracts;
    using System.ComponentModel.Design;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();
            IEngine engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceProvider serviceProvider = new ServiceContainer();
            
            return serviceProvider;
        }
    }
}
