#if UNITY_EDITOR
#define ENABLE_LOG
#endif

using UnityEngine;
using UnityEngine.Internal;
using System;
using Object = UnityEngine.Object;

public sealed class PieDebug
{
    private PieDebug() { }

    public static bool developerConsoleVisible
    {
        get { return UnityEngine.Debug.developerConsoleVisible; }
        set { UnityEngine.Debug.developerConsoleVisible = value; }
    }

    public static ILogger unityLogger
    {
        get { return UnityEngine.Debug.unityLogger; }
    }

    public static bool isDebugBuild
    {
        get { return UnityEngine.Debug.isDebugBuild; }
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void Assert(bool condition, string message, Object context)
    {
        UnityEngine.Debug.Assert(condition, message, context);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void Assert(bool condition, object message, Object context)
    {
        UnityEngine.Debug.Assert(condition, message, context);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void Assert(bool condition, string message)
    {
        UnityEngine.Debug.Assert(condition, message);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void Assert(bool condition, object message)
    {
        UnityEngine.Debug.Assert(condition, message);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void Assert(bool condition, Object context)
    {
        UnityEngine.Debug.Assert(condition, context);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void Assert(bool condition)
    {
        UnityEngine.Debug.Assert(condition);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    [Obsolete("Assert(bool, string, params object[]) is obsolete. Use AssertFormat(bool, string, params object[]) (UnityUpgradable) -> AssertFormat(*)", true)]
    public static void Assert(bool condition, string format, params object[] args)
    {
        UnityEngine.Debug.Assert(condition, format, args);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void AssertFormat(bool condition, string format, params object[] args)
    {
        UnityEngine.Debug.AssertFormat(condition, format, args);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void AssertFormat(bool condition, Object context, string format, params object[] args)
    {
        UnityEngine.Debug.AssertFormat(condition, context, format, args);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void Break()
    {
        UnityEngine.Debug.Break();
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void ClearDeveloperConsole()
    {
        UnityEngine.Debug.ClearDeveloperConsole();
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void DebugBreak()
    {
        UnityEngine.Debug.DebugBreak();
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void DrawLine(Vector3 start, Vector3 end, [UnityEngine.Internal.DefaultValue("Color.white")] Color color, [UnityEngine.Internal.DefaultValue("0.0f")] float duration, [UnityEngine.Internal.DefaultValue("true")] bool depthTest)
    {
        UnityEngine.Debug.DrawLine(start, end, color, duration, depthTest);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    [ExcludeFromDocs]
    public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration)
    {
        UnityEngine.Debug.DrawLine(start, end, color, duration);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    [ExcludeFromDocs]
    public static void DrawLine(Vector3 start, Vector3 end)
    {
        UnityEngine.Debug.DrawLine(start, end);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    [ExcludeFromDocs]
    public static void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        UnityEngine.Debug.DrawLine(start, end, color);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    [ExcludeFromDocs]
    public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration)
    {
        UnityEngine.Debug.DrawRay(start, dir, color, duration);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void DrawRay(Vector3 start, Vector3 dir, [UnityEngine.Internal.DefaultValue("Color.white")] Color color, [UnityEngine.Internal.DefaultValue("0.0f")] float duration, [UnityEngine.Internal.DefaultValue("true")] bool depthTest)
    {
        UnityEngine.Debug.DrawRay(start, dir, color, duration, depthTest);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    [ExcludeFromDocs]
    public static void DrawRay(Vector3 start, Vector3 dir)
    {
        UnityEngine.Debug.DrawRay(start, dir);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    [ExcludeFromDocs]
    public static void DrawRay(Vector3 start, Vector3 dir, Color color)
    {
        UnityEngine.Debug.DrawRay(start, dir, color);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void Log(object message, Object context)
    {
        UnityEngine.Debug.Log(message, context);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void Log(object message)
    {
        UnityEngine.Debug.Log(message);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogAssertion(object message, Object context)
    {
        UnityEngine.Debug.LogAssertion(message, context);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogAssertion(object message)
    {
        UnityEngine.Debug.LogAssertion(message);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogAssertionFormat(Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogAssertionFormat(context, format, args);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogAssertionFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogAssertionFormat(format, args);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogError(object message, Object context)
    {
        UnityEngine.Debug.LogError(message, context);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogError(object message)
    {
        UnityEngine.Debug.LogError(message);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogErrorFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogErrorFormat(format, args);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogErrorFormat(Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogErrorFormat(context, format, args);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogException(Exception exception, Object context)
    {
        UnityEngine.Debug.LogException(exception, context);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogException(Exception exception)
    {
        UnityEngine.Debug.LogException(exception);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogFormat(Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogFormat(context, format, args);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogFormat(format, args);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogWarning(object message)
    {
        UnityEngine.Debug.LogWarning(message);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogWarning(object message, Object context)
    {
        UnityEngine.Debug.LogWarning(message, context);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogWarningFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogWarningFormat(format, args);
    }

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void LogWarningFormat(Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogWarningFormat(context, format, args);
    }
}