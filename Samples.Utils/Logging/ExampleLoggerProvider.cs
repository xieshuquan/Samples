using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Samples.Utils.Logging
{
    public class ExampleLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, ExampleLogger> _loggers = new ConcurrentDictionary<string, ExampleLogger>();

        public readonly Func<string, LogLevel, bool> _filter;

        public ExampleLoggerProvider(Func<string, LogLevel, bool> filter)
        {
            _filter = filter;
        }

        public ExampleLoggerProvider()
            : this(null)
        {

        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        private ExampleLogger CreateLoggerImplementation(string categoryName) => new ExampleLogger(categoryName, _filter);


        public void Dispose()
        {
            //Todo
        }
    }
}
