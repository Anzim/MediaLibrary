using Microsoft.Extensions.Logging;
using System;

namespace MediaLibrary
{
        public class DbLoggerProvider : ILoggerProvider
        {
            public ILogger CreateLogger(string categoryName)
            {
                return new DbLogger();
            }

            public void Dispose()
            { }

            private class DbLogger : ILogger
            {
                public bool IsEnabled(LogLevel logLevel)
                {
                    return true;
                }

                public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
                {
                    //File.AppendAllText(@"C:\temp\log.txt", formatter(state, exception));
                    Console.WriteLine(formatter(state, exception));
                }

                public IDisposable BeginScope<TState>(TState state)
                {
                    return null;
                }
            }
        }
    
}
