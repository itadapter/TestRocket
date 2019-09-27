﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketConsole
{
  public static class ProgramConstants
  {
    public const string INTERACTIVE_STARTUP_MSG = "Welcome to Rocket Console";

    public const int SHUTDOWN_DELAY_SEC = 3;

    public const string MAIN_START_LOG_INFO_MSG = "Rocket Console Starting...";

    public const string MAIN_END_LOG_INFO_MSG = "Rocket Console Finished!";

    public const string MAIN_START_LOG_DEBUG_MSG = "Debug Mode Start:";

    public const string MAIN_END_LOG_DEBUG_MSG = "Debug Mode End:";

    public const LogLevel WORKER_MIN_LOG_LEVEL = LogLevel.Information;

    public const LogLevel PROGRAM_MIN_LOG_LEVEL = LogLevel.Debug;

    public const LogLevel PROGRAM_SYSTEM_MIN_LOG_LEVEL = LogLevel.Warning;

    public const LogLevel PROGRAM_MS_MIN_LOG_LEVEL = LogLevel.Warning;

    public const LogLevel PROGRAM_DEFAULT_MIN_LOG_LEVEL = LogLevel.Warning;
  }
}
