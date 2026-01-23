using BepInEx.Logging;
using JetBrains.Annotations;

namespace FrankenToilet.Core;

[PublicAPI]
public static class LogHelper
{
    public static void LogInfo(object message) => Plugin.Logger.LogInfo(message);
    public static void LogWarning(object message) => Plugin.Logger.LogWarning(message);
    public static void LogError(object message) => Plugin.Logger.LogError(message);
    public static void LogDebug(object message) => Plugin.Logger.LogDebug(message);
    public static void LogFatal(object message) => Plugin.Logger.LogFatal(message);
    public static void LogMessage(object message) => Plugin.Logger.LogMessage(message);
    public static void Log(LogLevel logLevel, object data) => Plugin.Logger.Log(logLevel, data);
}