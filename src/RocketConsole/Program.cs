using Factory.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RocketConsole
{
  class Program
  {
    public static ILogger<Program> m_ProgramLogger;

    static async Task Main(string[] args)
    {
      var services = new ServiceCollection();
      ConfigureServices(services, LogLevel.Trace);
      using (ServiceProvider serviceProvider = services.BuildServiceProvider())
      {
        /* Start Up */
        m_ProgramLogger = serviceProvider.GetService<ILogger<Program>>();
        m_WriteMainLogStart(m_ProgramLogger);

        Console.WriteLine(ProgramConstants.INTERACTIVE_STARTUP_MSG);

        /* Do Work */
        Worker app = serviceProvider.GetService<Worker>();
        await app.ExecuteAsync(CancellationToken.None);

        /* Shut Down */
        m_WriteMainLogEnd(m_ProgramLogger);
        await Task.Delay(TimeSpan.FromSeconds(ProgramConstants.SHUTDOWN_DELAY_SEC));
      }
    }

    private static void ConfigureServices(IServiceCollection services, LogLevel logLevel)
    {
      EventLogSettings e = m_GetEventLogSettings();

      services.AddLogging(configure =>
        configure.AddConsole()
                 .AddEventLog(m_GetEventLogSettings())
        )
        .AddTransient<IRocketLoader, RocketOrderFileLoader>()
        .AddTransient<Worker>();

      if (logLevel == LogLevel.Trace)
      {
        services.Configure<LoggerFilterOptions>(options =>
        {
          options.MinLevel = LogLevel.Trace;
          options.AddFilter("Microsoft", LogLevel.Warning);
          options.AddFilter("System", LogLevel.Warning);
          options.AddFilter(nameof(RocketConsole.Program), LogLevel.Debug);
          //options.AddFilter("RocketConsole.Worker", LogLevel.Warning);
        });
      }
      else
      {
        services.Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Error);
      }
    }

    private static void m_WriteMainLogStart(ILogger logger)
    {
      logger.LogInformation(ProgramConstants.MAIN_START_LOG_INFO_MSG);
      logger.LogDebug(ProgramConstants.MAIN_START_LOG_DEBUG_MSG);
    }

    private static void m_WriteMainLogEnd(ILogger logger)
    {
      logger.LogDebug(ProgramConstants.MAIN_END_LOG_DEBUG_MSG);
      logger.LogInformation(ProgramConstants.MAIN_END_LOG_INFO_MSG);
    }

    private static EventLogSettings m_GetEventLogSettings()
    {
      return new EventLogSettings
      {
        Filter = (string category, LogLevel level) =>
        {
          if (category == "RocketConsole.Worker" && level > LogLevel.Debug) return true;
          return false;
        }
      };
    }
  }
}
