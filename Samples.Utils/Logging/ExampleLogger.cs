using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.Utils.Logging
{
    public class ExampleLogger : ILogger
    {
        public string CategoryName { get; private set; }
        public Func<string, LogLevel, bool> Filter { get; private set; }

        public ExampleLogger(string categoryName, Func<string, LogLevel, bool> filter)
        {
            CategoryName = categoryName;
            Filter = filter;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return LogLevel.None != logLevel && (Filter == null || Filter(CategoryName, logLevel));
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            if (!string.IsNullOrEmpty(message) || exception != null)
            {
                WriteMessage(logLevel, CategoryName, eventId.Id, message, exception);
            }
        }

        public virtual void WriteMessage(LogLevel logLevel, string logName, int eventId, string message, Exception exception)
        {
            Console.WriteLine($"Level: {logLevel.ToString()}{Environment.NewLine}Message: {message}{Environment.NewLine}Exception: {exception?.ToString()}{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}");
        }

    }
}
