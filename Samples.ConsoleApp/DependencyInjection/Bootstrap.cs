using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.ConsoleApp.DependencyInjection
{
    public class Bootstrap
    {
        public void Run(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IPrint, PrintA>();
            services.AddTransient<IPrint, PrintB>();
            var serviceProvider = services.BuildServiceProvider(validateScopes: true);
            using (var scope = serviceProvider.CreateScope())
            {
                var types = scope.ServiceProvider.GetServices<IPrint>();
                foreach (var type in types)
                    type.Println();
            }
        }
    }
}
