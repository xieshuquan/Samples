using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Samples.ConsoleApp.Configuration
{
    public class Bootstrap
    {
        public void Run(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Configuration");
            var builder = new ConfigurationBuilder().SetBasePath(basePath)
                //Microsoft.Extensions.Configuration.Json
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                //Microsoft.Extensions.Configuration.Xml
                .AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true)
 
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["People:Name"] = "小华",
                    ["People:Age"] = "2000",
                })
                //Microsoft.Extensions.Configuration.CommandLine
                .AddCommandLine(args);

            //Microsoft.Extensions.Configuration.Binder
            var configuration = builder.Build();
            var people = new People();
            var child = new Child();
            var names = new List<Item>();
            configuration.GetSection("People").Bind(people);
            configuration.Bind("Child", child);
            configuration.Bind("Array:Names", names);

            Console.WriteLine($"Name: {configuration.GetValue<string>("Array:Names:0:Name")}");
            Console.WriteLine($"Names: {string.Join(", ", names?.Select(x => x.Name) ?? new List<string>())}");
            Console.WriteLine($"Name: {people.Name}{Environment.NewLine}Age: {people.Age}");
            Console.WriteLine($"Name: {child.Name}{Environment.NewLine}Age: {child.Age}");

        }
    }
}
