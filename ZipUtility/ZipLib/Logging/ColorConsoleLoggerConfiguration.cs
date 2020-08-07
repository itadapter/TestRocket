﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace ZipLib.Logging
{
  public class ColorConsoleLoggerConfiguration
  {
    public LogLevel LogLevel { get; set; } = LogLevel.Warning;
    public int EventId { get; set; } = 0;
    public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
  }
}
