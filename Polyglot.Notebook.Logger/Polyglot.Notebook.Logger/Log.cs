namespace Polyglot.Notebook.Logger;

public class Log
{
    #region Constants

    public const string BLACK = "\u001b[30m";
    public const string RED = "\u001b[31m";
    public const string GREEN = "\u001b[32m";
    public const string YELLOW = "\u001b[33m";
    public const string BLUE = "\u001b[34m";
    public const string MAGENTA = "\u001b[35m";
    public const string CYAN = "\u001b[36m";
    public const string WHITE = "\u001b[37m";
    public const string BR_BLACK = "\u001b[90m";
    public const string BR_RED = "\u001b[91m";
    public const string BR_GREEN = "\u001b[92m";
    public const string BR_YELLOW = "\u001b[93m";
    public const string BR_BLUE = "\u001b[94m";
    public const string BR_MAGENTA = "\u001b[95m";
    public const string BR_CYAN = "\u001b[96m";
    public const string BR_WHITE = "\u001b[97m";
    public const string BG_BLACK = "\u001b[40m";
    public const string BG_RED = "\u001b[41m";
    public const string BG_GREEN = "\u001b[42m";
    public const string BG_YELLOW = "\u001b[43m";
    public const string BG_BLUE = "\u001b[44m";
    public const string BG_MAGENTA = "\u001b[45m";
    public const string BG_CYAN = "\u001b[46m";
    public const string BG_WHITE = "\u001b[47m";
    public const string BG_BR_BLACK = "\u001b[100m";
    public const string BG_BR_RED = "\u001b[101m";
    public const string BG_BR_GREEN = "\u001b[102m";
    public const string BG_BR_YELLOW = "\u001b[103m";
    public const string BG_BR_BLUE = "\u001b[104m";
    public const string BG_BR_MAGENTA = "\u001b[105m";
    public const string BG_BR_CYAN = "\u001b[106m";
    public const string BG_BR_WHITE = "\u001b[107m";

    public const string END = "\u001b[0m";
    #endregion


    #region Public Static Methods

    public static void Debug(string message)
    {
        Console.WriteLine($"{DateColor}{DateTime.Now.ToString(DateTimeFormat)}{END} {SEP} {TypeDebugColor}{TypeDebugText}{END} {SEP} {MessageDebugColor}{message}{END}");
    }

    public static void Info(string message)
    {
        Console.WriteLine($"{DateColor}{DateTime.Now.ToString(DateTimeFormat)}{END} {SEP} {TypeInfoColor}{TypeDebugText}{END} {SEP} {MessageInfoColor}{message}{END}");
    }

    public static void Warn(string message)
    {
        Console.WriteLine($"{DateColor}{DateTime.Now.ToString(DateTimeFormat)}{END} {SEP} {TypeWarnColor}{TypeWarnText}{END} {SEP} {MessageWarnColor}{message}{END}");
    }

    public static void Error(string message)
    {
        Console.WriteLine($"{DateColor}{DateTime.Now.ToString(DateTimeFormat)}{END} {SEP} {TypeBackgroundErrorColor}{TypeErrorColor}{TypeErrorText}{END} {SEP} {MessageErrorColor}{message}{END}");
    }

    public static void Critical(string message)
    {
        Console.WriteLine($"{DateColor}{DateTime.Now.ToString(DateTimeFormat)}{END} {SEP} {TypeBackgroundCriticalColor}{TypeCriticalColor}{TypeCriticalText}{END} {SEP} {BG_BR_RED}{MessageCriticalColor}{message}{END}");
    }
    #endregion

    #region Public Properties

    public static string DateColor { get; set; } = BR_MAGENTA;
    public static string SeparatorColor { get; set; } = BR_WHITE;

    public static string TypeDebugColor { get; set; } = BR_BLUE;
    public static string TypeInfoColor { get; set; } = BR_GREEN;
    public static string TypeWarnColor { get; set; } = BR_YELLOW;
    public static string TypeErrorColor { get; set; } = WHITE;
    public static string TypeCriticalColor { get; set; } = WHITE;
    public static string TypeBackgroundErrorColor { get; set; } = BG_BR_RED;
    public static string TypeBackgroundCriticalColor { get; set; } = BG_BR_RED;

    public static string MessageDebugColor { get; set; } = BLUE;
    public static string MessageInfoColor { get; set; } = GREEN;
    public static string MessageWarnColor { get; set; } = YELLOW;
    public static string MessageErrorColor { get; set; } = RED;
    public static string MessageCriticalColor { get; set; } = WHITE;

    public static string TypeDebugText { get; set; } = "Debug";
    public static string TypeInfoText { get; set; } = "Info ";
    public static string TypeWarnText { get; set; } = "Warn ";
    public static string TypeErrorText { get; set; } = "Err  ";
    public static string TypeCriticalText { get; set; } = "Crit ";

    public static string DateTimeFormat { get; set; } = "dd hh:mm:ss.ff";

    #endregion

    #region Private Properties
    static string SEP => $"{SeparatorColor}|{END}";
    #endregion

}
