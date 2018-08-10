using System;

namespace Samples.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new DependencyInjection.Bootstrap().Run(args);
            new Configuration.Bootstrap().Run(args);
        }
    }
}
