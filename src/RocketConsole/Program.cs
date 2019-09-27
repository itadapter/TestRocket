using Factory.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.EventLog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RocketConsole
{
  class Program
  {
    public static ILogger<Program> m_ProgramLogger;
    public static IWorker m_Worker;

    static async Task Main(string[] args)
    {
      await Run<Worker>();
    }

    private static async Task Run<T>()
    {
      var services = new ServiceCollection();
      ConfigureServices(services, typeof(T));
      using (ServiceProvider serviceProvider = services.BuildServiceProvider())
      {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
          builder
              .AddFilter("Microsoft", LogLevel.Warning)
              .AddFilter("System", LogLevel.Warning)
              //.AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)

              .AddFilter((provider, category, level) =>
              {
                if (provider == "Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider" &&
                level >= LogLevel.Trace
                    //category == "TodoApiSample.Controllers.TodoController"
                    )
                {
                  return true;
                }

                if (provider == "Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider" &&
                level < LogLevel.Warning
                    //category == "TodoApiSample.Controllers.TodoController"
                    )
                {
                  return false;
                }

                //return true;

                if (category == m_Worker.GetType().FullName && level >= LogLevel.Trace)
                {
                  return true;
                }
                else if (category == typeof(Program).FullName && level >= ProgramConstants.PROGRAM_MIN_LOG_LEVEL)
                {
                  return true;
                }
                return category switch
                {
                  "Microsoft" => m_ShouldLog(level, ProgramConstants.PROGRAM_MS_MIN_LOG_LEVEL),
                  "System" => m_ShouldLog(level, ProgramConstants.PROGRAM_SYSTEM_MIN_LOG_LEVEL),
                  _ => m_ShouldLog(level, ProgramConstants.PROGRAM_DEFAULT_MIN_LOG_LEVEL),
                };
              })

              .AddConsole()
              .AddEventLog();
        });
        m_ProgramLogger = loggerFactory.CreateLogger<Program>();




        //m_ProgramLogger = serviceProvider.GetService<ILogger<Program>>();
        m_Worker = serviceProvider.GetRequiredService(typeof(T)) as IWorker;

        /* Start Up */
        m_WriteMainLogStart();

        /* if we are interactive we want to welcome user */
        Console.WriteLine(ProgramConstants.INTERACTIVE_STARTUP_MSG);
        m_ProgramLogger.LogDebug("Hello from Program");
        //Console.WriteLine(typeof(Program).FullName);

        /* Do Work HERE*/
        m_ProgramLogger.LogDebug(m_Worker.GetType().FullName);
        await m_Worker.ExecuteAsync(CancellationToken.None);
        /* Do Work HERE*/

        /* Shut Down */
        m_WriteMainLogEnd();
        await Task.Delay(TimeSpan.FromSeconds(ProgramConstants.SHUTDOWN_DELAY_SEC));
      }
    }

    private static void ConfigureServices(IServiceCollection services, Type workerType)
    {
      //EventLogSettings e = m_GetEventLogSettings();

      services.AddLogging(configure =>
        configure.AddEventLog(m_GetEventLogSettings())
        .AddConsole()
        )

        //.AddLogging(configure =>
        //configure.AddEventLog(m_GetEventLogSettings())
        //.AddConsole(logging =>
        //{
        //  logging.LogToStandardErrorThreshold = LogLevel.Trace;
        //})
        //)
        .AddTransient<IRocketLoader, RocketOrderFileLoader>()
        .AddTransient(workerType);

      //services.Configure<LoggerFilterOptions>(options =>
      //{
      //  options.MinLevel = LogLevel.Trace;
      //  options.AddFilter("Microsoft", LogLevel.Warning);
      //  options.AddFilter("System", LogLevel.Warning);
      //  //options.AddFilter(typeof(Program).FullName, LogLevel.Debug);
      //  //options.AddFilter("RocketConsole.Worker", LogLevel.Warning);
      //});
    }

    private static void m_WriteMainLogStart()
    {
      m_ProgramLogger.LogInformation(ProgramConstants.MAIN_START_LOG_INFO_MSG);
      m_ProgramLogger.LogDebug(ProgramConstants.MAIN_START_LOG_DEBUG_MSG);
    }

    private static void m_WriteMainLogEnd()
    {
      m_ProgramLogger.LogDebug(ProgramConstants.MAIN_END_LOG_DEBUG_MSG);
      m_ProgramLogger.LogInformation(ProgramConstants.MAIN_END_LOG_INFO_MSG);
    }

    private static EventLogSettings m_GetEventLogSettings()
    {
      return new EventLogSettings
      {
        Filter = (string category, LogLevel level) =>
        {
          if (category == m_Worker.GetType().FullName && level >= ProgramConstants.WORKER_MIN_LOG_LEVEL)
          {
            return true;
          }
          else if (category == typeof(Program).FullName && level >= ProgramConstants.PROGRAM_MIN_LOG_LEVEL)
          {
            return true;
          }
          return category switch
          {
            "Microsoft" => m_ShouldLog(level, ProgramConstants.PROGRAM_MS_MIN_LOG_LEVEL),
            "System" => m_ShouldLog(level, ProgramConstants.PROGRAM_SYSTEM_MIN_LOG_LEVEL),
            _ => m_ShouldLog(level, ProgramConstants.PROGRAM_DEFAULT_MIN_LOG_LEVEL),
          };

        }
      };
    }


    private static bool m_ShouldLog(LogLevel level, LogLevel minLogLevel)
    {
      if (level >= minLogLevel) return true;
      return false;
    }
  }
}
