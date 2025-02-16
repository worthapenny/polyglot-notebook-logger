using System.Collections;
using System.Text;

namespace Polyglot.Notebook.Logger;

public class Log
{
    #region Constants
    const string END = "\u001b[0m";
    #endregion


    #region Public Static Methods

    public static void Debug(string message)
    {
        message = $"{GetPrefixName()}{message}";
        Console.WriteLine($"{DateColor}{DateTime.Now.ToString(DateTimeFormat)}{END} {SEP} {TypeColors.Debug}{Text.TypeDebug}{END} {SEP} {MessageColors.Debug}{message}{END}");
    }

    public static void Info(string message)
    {
        message = $"{GetPrefixName()}{message}";
        Console.WriteLine($"{DateColor}{DateTime.Now.ToString(DateTimeFormat)}{END} {SEP} {TypeColors.Info}{Text.TypeInfo}{END} {SEP} {MessageColors.Info}{message}{END}");
    }

    public static void Warn(string message)
    {
        message = $"{GetPrefixName()}{message}";
        Console.WriteLine($"{DateColor}{DateTime.Now.ToString(DateTimeFormat)}{END} {SEP} {TypeColors.Warn}{Text.TypeWarn}{END} {SEP} {MessageColors.Warn}{message}{END}");
    }

    public static void Error(string message)
    {
        message = $"{GetPrefixName()}{message}";
        Console.WriteLine($"{DateColor}{DateTime.Now.ToString(DateTimeFormat)}{END} {SEP} {TypeColors.BackgroundError}{TypeColors.Error}{Text.TypeError}{END} {SEP} {MessageColors.Error}{message}{END}");
    }

    public static void Error(Exception ex, string message)
    {
        message = $"{GetPrefixName()}{message}";
        Console.WriteLine($"{DateColor}{DateTime.Now.ToString(DateTimeFormat)}{END} {SEP} {TypeColors.BackgroundError}{TypeColors.Error}{Text.TypeError}{END} {SEP} {MessageColors.Error}{message}{END}");
        LogException(ex);
    }

    public static void Critical(string message)
    {
        message = $"{GetPrefixName()}{message}";
        Console.WriteLine($"{DateColor}{DateTime.Now.ToString(DateTimeFormat)}{END} {SEP} {TypeColors.BackgroundCritical}{TypeColors.Critical}{Text.TypeCritical}{END} {SEP} {TypeColors.BackgroundCritical}{MessageColors.Critical}{message}{END}");
    }
    #endregion

    #region Private Methods
    private static void LogException(Exception ex, bool includeStackTrace = true, bool includeData = true)
    {
        LogExceptionRecursive(ex, 0, includeStackTrace, includeData);
    }

    private static void LogExceptionRecursive(Exception ex, int depth, bool includeStackTrace, bool includeData)
    {
        if (ex == null) return;
        ex.Data["At"] = $"{DateTime.UtcNow:u}";

        // Indent based on depth for nested exceptions
        string indent = new string(' ', depth * 4);

        // Basic exception information
        Console.WriteLine($"{DateColor}{DateTime.Now.ToString(DateTimeFormat)}{END} {SEP} {TypeColors.BackgroundError}{TypeColors.Error}{Text.TypeError}{END} {SEP} {MessageColors.Error} {ex.Message}{END}");
        Console.WriteLine($"{indent}{TypeColors.BackgroundError}{TypeColors.Error}Exception Type:{END} {ex.GetType().FullName}");
        Console.WriteLine($"{indent}{TypeColors.BackgroundError}{TypeColors.Error}Source:{END} {TypeColors.Error}{ex.Source}{END}");

        // Exception Data dictionary
        if (includeData && ex.Data.Count > 0)
        {
            Console.WriteLine($"{indent}{TypeColors.BackgroundError}{TypeColors.Error}Additional Data:{END}");
            foreach (DictionaryEntry entry in ex.Data)
            {
                Console.WriteLine($"{indent}    {TypeColors.BackgroundError}{TypeColors.Error}{entry.Key}{END}: {TypeColors.Error}{entry.Value}{END}");
            }
        }

        // Stack Trace (formatted for readability)
        if (includeStackTrace && !string.IsNullOrEmpty(ex.StackTrace))
        {
            Console.WriteLine($"{indent}Stack Trace:");
            var stackLines = ex.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in stackLines)
            {
                Console.WriteLine($"{indent}    {TypeColors.Error}{line.Trim()}{END}");
            }
        }

        // Handle inner exception
        if (ex.InnerException != null)
        {
            Console.WriteLine($"{indent}{TypeColors.BackgroundError}{TypeColors.Error}Inner Exception:{END}");
            LogExceptionRecursive(ex.InnerException, depth + 1, includeStackTrace, includeData);
        }

        // Handle aggregate exceptions
        if (ex is AggregateException aggEx)
        {
            Console.WriteLine($"{indent}{TypeColors.BackgroundError} {TypeColors.Error} Aggregate Exceptions: {END}");
            foreach (var innerEx in aggEx.InnerExceptions)
            {
                LogExceptionRecursive(innerEx, depth + 1, includeStackTrace, includeData);
            }
        }
    }
    private static string GetPrefixName()
    {
        return string.IsNullOrEmpty(PrefixName)
            ? string.Empty 
            : $"[{PrefixName}] ";
    }
    #endregion

    #region Public Properties

    public static string DateColor { get; set; } = ColorConstants.BR_MAGENTA;
    public static string SeparatorColor { get; set; } = ColorConstants.BR_WHITE;
    public static string DateTimeFormat { get; set; } = "dd hh:mm:ss.ff";

    #endregion

    #region Public Properties
    public static string PrefixName { get; set; } = string.Empty;

    #endregion


    #region Private Properties
    static string SEP => $"{SeparatorColor}|{END}";
    #endregion


    #region Helper Classes
    public static class TypeColors
    {
        public static string Debug { get; set; } = ColorConstants.BR_BLUE;
        public static string Info { get; set; } = ColorConstants.BR_GREEN;
        public static string Warn { get; set; } = ColorConstants.BR_YELLOW;
        public static string Error { get; set; } = ColorConstants.WHITE;
        public static string Critical { get; set; } = ColorConstants.WHITE;
        public static string BackgroundError { get; set; } = ColorConstants.BG_BR_RED;
        public static string BackgroundCritical { get; set; } = ColorConstants.BG_BR_RED;
    }

    public static class MessageColors
    {
        public static string Debug { get; set; } = ColorConstants.BLUE;
        public static string Info { get; set; } = ColorConstants.GREEN;
        public static string Warn { get; set; } = ColorConstants.YELLOW;
        public static string Error { get; set; } = ColorConstants.RED;
        public static string Critical { get; set; } = ColorConstants.WHITE;
    }

    

    public static class Text
    {
        #region Public Static Properties
        public static string TypeDebug { get; set; } = "Debug";
        public static string TypeInfo { get; set; } = "Info ";
        public static string TypeWarn { get; set; } = "Warn ";
        public static string TypeError { get; set; } = "Err  ";
        public static string TypeCritical { get; set; } = "Crit ";

        public static int MaxTypeTexLength { get; set; } = 5;
        #endregion
    }
    #endregion

}
