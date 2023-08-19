namespace Sparkle.csharp; 

public static class SystemInfo {

    /// <summary>
    /// Gets the CPU identifier string or "Unknown" if not available.
    /// </summary>
    public static string Cpu => Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER") ?? "Unknown";

    /// <summary>
    /// Gets the total available memory size in gigabytes (GB).
    /// </summary>
    public static int MemorySize => (int) (GC.GetGCMemoryInfo().TotalAvailableMemoryBytes / 1048576.0F) / 1000;

    /// <summary>
    /// Gets the number of available processor threads.
    /// </summary>
    public static int Threads => Environment.ProcessorCount;

    /// <summary>
    /// Gets the operating system version string.
    /// </summary>
    public static string Os => Environment.OSVersion.VersionString;
}