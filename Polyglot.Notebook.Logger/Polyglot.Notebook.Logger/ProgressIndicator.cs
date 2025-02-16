using System;
using System.Text;

namespace Polyglot.Notebook.Logger;

public class ProgressIndicator
{
    #region Constants

    const string END = "\u001b[0m";
    #endregion

    #region Private Properties
    private readonly int maxCount;
    private readonly string label;
    private readonly int reportOnEveryNthItem;
    private readonly int barSize;
    private int currentIndex;
    private readonly DateTime startTime;
    private DateTime lastReportTime;
    //private char progressBlock = '';

    public TimeSpan Elapsed => DateTime.Now - startTime;
    #endregion

    #region Public Properties
    public string ProgressPercentColor { get; set; } = ColorConstants.MAGENTA;
    public string ProgressBarColor { get; set; } = ColorConstants.GREEN;
    public string ProgressValueColor { get; set; } = ColorConstants.CYAN;
    public string ProgressRateColor { get; set; } = ColorConstants.BLUE;
    public string ProgressETAColor { get; set; } = ColorConstants.YELLOW;
    public string ProgressLabelColor { get; set; } = ColorConstants.GREEN;
    public static string SeparatorColor { get; set; } = ColorConstants.BR_WHITE;

    #endregion

    #region Constructor
    public ProgressIndicator(
        int maxCount,
        string label,
        int reportOnEveryNthItem = 1,
        int barSize = 30)
    {
        this.maxCount = maxCount;
        this.label = label;
        this.reportOnEveryNthItem = reportOnEveryNthItem;
        this.barSize = barSize;
        this.currentIndex = 0;
        this.startTime = DateTime.Now;
        this.lastReportTime = DateTime.Now;
    }
    #endregion

    #region  Public Methods
    public (int, string)? Increment(int incrementBy = 1, bool doLog = true)
    {
        currentIndex += incrementBy;
        if (currentIndex % reportOnEveryNthItem == 0)
        {
            return GenerateReport(doLog);
        }
        return null;
    }

    #endregion

    #region Private Methods

    private (int, string) GenerateReport(bool doLog)
    {
        double at = (double)currentIndex / maxCount;
        double atPct = at * 100;
        int doneBarSize = (int)(at * barSize);
        int remainBarSize = barSize - doneBarSize;

        string percent = $"{ProgressPercentColor}{atPct:F1}%{END}";
        string bar = $"{ProgressBarColor}[{new string('■', doneBarSize)}{new string('.', remainBarSize)}]{END}";
        string separation = $"{SeparatorColor}|{END}";
        string value = $"{ProgressValueColor}{currentIndex}/{maxCount}{END}";

        DateTime currentTime = DateTime.Now;
        TimeSpan timeRate = currentTime - lastReportTime;
        string rate = $"{ProgressRateColor}{FormatTimeSpan(Elapsed)} @ {FormatTimeSpan(timeRate)}/it{END}";
        lastReportTime = currentTime;


        string eta = CalculateETA(at);
        string etaReport = $"{ProgressETAColor}ETA: {eta}{END}";
        string labelReport = $"{ProgressLabelColor}{label}{END}";

        string report = $"{percent} {bar} {separation} {value} {separation} " +
                       $"{rate} {etaReport} {separation} {labelReport}";

        if (doLog)
        {
            Console.WriteLine(report); // Replace with your logging framework
        }

        return (currentIndex, report);
    }

    private string FormatTimeSpan(TimeSpan ts)
    {
        int totalSeconds = (int)ts.TotalSeconds;
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        int milliseconds = ts.Milliseconds;

        if (minutes == 0)
        {
            return $"{seconds}.{milliseconds:D3}";
        }
        else
        {
            return $"{minutes}:{seconds:D2}.{milliseconds:D3}";
        }
    }

    private string CalculateETA(double at)
    {
        if (at == 0)
        {
            return "N/A";
        }

        double elapsedSeconds = Elapsed.TotalSeconds;
        double totalEstimatedSeconds = elapsedSeconds / at;
        double etaSeconds = totalEstimatedSeconds - elapsedSeconds;

        return TimeSpan.FromSeconds(etaSeconds).ToString(@"hh\:mm\:ss");
    }

    #endregion
}