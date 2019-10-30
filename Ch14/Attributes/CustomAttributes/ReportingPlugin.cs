namespace CustomAttributes
{
    // Examples 18 and 19 show two variants of the same class. Switch
    // between #if true and #if false to choose which one to build.
#if true
    [PluginInformation("Reporting", "Endjin Ltd.")]
    public class ReportingPlugin
    {
    }
#else
    [PluginInformation("Reporting", "Endjin Ltd.",
        Description = "Automated report generation")]
    public class ReportingPlugin
    {
    }
#endif
}