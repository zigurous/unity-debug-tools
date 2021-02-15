using System.Text;

namespace Zigurous.Debugging
{
    /// <summary>
    /// Provides more robust console logging functions compared to
    /// UnityEngine.Debug.
    /// </summary>
    public static class Debug
    {
        /// <summary>
        /// A prefix appended to every log message printed to the console.
        /// </summary>
        public static string prefix = "[Zigurous]: ";

        /// <summary>
        /// The display string for any null references that are logged to the
        /// console.
        /// </summary>
        public static string nullReference = "Null";

        /// <summary>
        /// The delimiter used when joining multiple messages into a single log
        /// message printed to the console.
        /// </summary>
        public static string delimiter = ", ";

        #if UNITY_EDITOR || DEVELOPMENT_BUILD
        /// <summary>
        /// Handles the creation of strings in a more optimized way.
        /// </summary>
        private static StringBuilder stringBuilder = new StringBuilder();
        #endif

        /// <summary>
        /// Logs a message to the Unity console.
        /// </summary>
        public static void Log(object message)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (message != null) {
                UnityEngine.Debug.Log(stringBuilder.Append(Debug.prefix).Append(message));
            } else {
                UnityEngine.Debug.Log(stringBuilder.Append(Debug.prefix).Append(Debug.nullReference));
            }
            stringBuilder.Clear();
            #endif
        }

        /// <summary>
        /// Logs a message to the Unity console under a given context.
        /// </summary>
        public static void Log(object message, UnityEngine.Object context)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (message != null) {
                UnityEngine.Debug.Log(stringBuilder.Append(Debug.prefix).Append(message), context);
            } else {
                UnityEngine.Debug.Log(stringBuilder.Append(Debug.prefix).Append(Debug.nullReference), context);
            }
            stringBuilder.Clear();
            #endif
        }

        /// <summary>
        /// Logs multiple messages as a single statement to the Unity console.
        /// </summary>
        public static void Log(params object[] messages)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            stringBuilder.Append(Debug.prefix);
            Join(messages);
            UnityEngine.Debug.Log(stringBuilder);
            stringBuilder.Clear();
            #endif
        }

        /// <summary>
        /// Logs a warning message to the Unity console.
        /// </summary>
        public static void LogWarning(object message)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (message != null) {
                UnityEngine.Debug.LogWarning(stringBuilder.Append(Debug.prefix).Append(message));
            } else {
                UnityEngine.Debug.LogWarning(stringBuilder.Append(Debug.prefix).Append(Debug.nullReference));
            }
            stringBuilder.Clear();
            #endif
        }

        /// <summary>
        /// Logs a warning message to the Unity console under a given context.
        /// </summary>
        public static void LogWarning(object message, UnityEngine.Object context)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (message != null) {
                UnityEngine.Debug.LogWarning(stringBuilder.Append(Debug.prefix).Append(message), context);
            } else {
                UnityEngine.Debug.LogWarning(stringBuilder.Append(Debug.prefix).Append(Debug.nullReference), context);
            }
            stringBuilder.Clear();
            #endif
        }

        /// <summary>
        /// Logs multiple warning messages as a single statement to the Unity
        /// console.
        /// </summary>
        public static void LogWarning(params object[] messages)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            stringBuilder.Append(Debug.prefix);
            Join(messages);
            UnityEngine.Debug.LogWarning(stringBuilder);
            stringBuilder.Clear();
            #endif
        }

        /// <summary>
        /// Logs an error message to the Unity console.
        /// </summary>
        public static void LogError(object message)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (message != null) {
                UnityEngine.Debug.LogError(stringBuilder.Append(Debug.prefix).Append(message));
            } else {
                UnityEngine.Debug.LogError(stringBuilder.Append(Debug.prefix).Append(Debug.nullReference));
            }
            stringBuilder.Clear();
            #endif
        }

        /// <summary>
        /// Logs an error message to the Unity console under a given context.
        /// </summary>
        public static void LogError(object message, UnityEngine.Object context)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (message != null) {
                UnityEngine.Debug.LogError(stringBuilder.Append(Debug.prefix).Append(message), context);
            } else {
                UnityEngine.Debug.LogError(stringBuilder.Append(Debug.prefix).Append(Debug.nullReference), context);
            }
            stringBuilder.Clear();
            #endif
        }

        /// <summary>
        /// Logs multiple error messages as a single statement to the Unity
        /// console.
        /// </summary>
        public static void LogError(params object[] messages)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            stringBuilder.Append(Debug.prefix);
            Join(messages);
            UnityEngine.Debug.LogError(stringBuilder);
            stringBuilder.Clear();
            #endif
        }

        /// <summary>
        /// Joins multiple messages into a single message.
        /// </summary>
        private static void Join(object[] messages)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (messages == null)
            {
                stringBuilder.Append(Debug.nullReference);
                return;
            }

            for (int i = 0; i < messages.Length - 1; i++)
            {
                object message = messages[i];

                if (message != null) {
                    stringBuilder.Append(message).Append(Debug.delimiter);
                } else {
                    stringBuilder.Append(Debug.nullReference).Append(Debug.delimiter);
                }
            }

            if (messages.Length > 0)
            {
                object lastMessage = messages[messages.Length - 1];

                if (lastMessage != null) {
                    stringBuilder.Append(lastMessage);
                } else {
                    stringBuilder.Append(Debug.nullReference);
                }
            }
            #endif
        }

    }

}
