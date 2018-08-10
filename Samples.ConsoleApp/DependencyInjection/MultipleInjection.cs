using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.ConsoleApp.DependencyInjection
{
    public interface IPrint
    {
        void Println();
    }

    public class PrintA : IPrint
    {
        public void Println()
        {
            Console.WriteLine($"type: {this.GetType().Name}");
        }
    }

    public class PrintB : IPrint
    {
        public void Println()
        {
            Console.WriteLine($"type: {this.GetType().Name}");
        }
    }

    public class PrintC : IPrint
    {
        public void Println()
        {
            Console.WriteLine($"type: {this.GetType().Name}");
        }
    }

    public class PrintD : IPrint
    {
        public void Println()
        {
            Console.WriteLine($"type: {this.GetType().Name}");
        }
    }
}
