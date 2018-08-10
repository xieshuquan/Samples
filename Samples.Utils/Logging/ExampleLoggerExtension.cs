using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Samples.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.Logging
{
    public static class ExampleLoggerExtension
    {
        public static ILoggingBuilder AddExample(this ILoggingBuilder builder)
        {
            builder.AddProvider(new ExampleLoggerProvider());
            return builder;
        }

        public static ILoggerFactory AddExample(this ILoggerFactory factory, Func<string, LogLevel, bool> filter)
        {
            factory.AddProvider(new ExampleLoggerProvider(filter));
            return factory;
        }

        public static ILoggerFactory AddExample(this ILoggerFactory factory)
        {
            factory.AddExample(null);
            return factory;
        }
    }
}
