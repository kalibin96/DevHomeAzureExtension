﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using DevHome.Logging;
using Windows.Storage;

namespace DevHomeAzureExtension.Widgets;

[System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Logging project is shared")]
public class Log
{
    private static Logger? _logger;

    public static Logger? Logger()
    {
        try
        {
            _logger ??= new Logger("Widgets", GetLoggingOptions());
        }
        catch
        {
            // Do nothing if logger fails.
        }

        return _logger;
    }

    public static Options GetLoggingOptions()
    {
        return new Options
        {
            LogFileFolderRoot = ApplicationData.Current.TemporaryFolder.Path,
            LogFileName = "Widgets_{now}.log",
            LogFileFolderName = "Widgets",
            DebugListenerEnabled = true,
#if DEBUG
            LogStdoutEnabled = true,
            LogStdoutFilter = SeverityLevel.Debug,
            LogFileFilter = SeverityLevel.Debug,
#else
            LogStdoutEnabled = false,
            LogStdoutFilter = SeverityLevel.Info,
            LogFileFilter = SeverityLevel.Info,
#endif
            FailFastSeverity = FailFastSeverityLevel.Critical,
        };
    }
}
