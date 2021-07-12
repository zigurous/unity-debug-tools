using System.Text;

namespace Zigurous.Debug
{
    /// <summary>
    /// Provides more robust console logging functions compared to
    /// UnityEngine.Debug.
    /// </summary>
    public static class Log
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
        /// <param name="message">The message to log.</param>
        public static void Message(object message)
        {
            Message(message, Log.prefix);
        }

        /// <summary>
        /// Logs a message to the Unity console with a custom prefix.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="prefix">The prefix of the message.</param>
        public static void Message(object message, string prefix)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            stringBuilder.Clear();

            if (message != null) {
                UnityEngine.Debug.Log(stringBuilder.Append(prefix).Append(message));
            } else {
                UnityEngine.Debug.Log(stringBuilder.Append(prefix).Append(Log.nullReference));
            }
            #endif
        }

        /// <summary>
        /// Logs a message to the Unity console under a given context.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="context">The context of the message.</param>
        public static void Message(object message, UnityEngine.Object context)
        {
            Message(message, Log.prefix, context);
        }

        /// <summary>
        /// Logs a message to the Unity console with a custom prefix under a
        /// given context.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="prefix">The prefix of the message.</param>
        /// <param name="context">The context of the message.</param>
        public static void Message(object message, string prefix, UnityEngine.Object context)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            stringBuilder.Clear();

            if (message != null) {
                UnityEngine.Debug.Log(stringBuilder.Append(prefix).Append(message), context);
            } else {
                UnityEngine.Debug.Log(stringBuilder.Append(prefix).Append(Log.nullReference), context);
            }
            #endif
        }

        /// <summary>
        /// Logs multiple messages as a single message to the Unity console.
        /// </summary>
        /// <param name="messages">The messages to log.</param>
        public static void Message(params object[] messages)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            stringBuilder.Clear();
            stringBuilder.Append(Log.prefix);
            stringBuilder.Join(messages);
            UnityEngine.Debug.Log(stringBuilder);
            #endif
        }

        /// <summary>
        /// Logs a warning message to the Unity console.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Warning(object message)
        {
            Warning(message, Log.prefix);
        }

        /// <summary>
        /// Logs a warning message to the Unity console with a custom prefix.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="prefix">The prefix of the message.</param>
        public static void Warning(object message, string prefix)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            stringBuilder.Clear();

            if (message != null) {
                UnityEngine.Debug.LogWarning(stringBuilder.Append(prefix).Append(message));
            } else {
                UnityEngine.Debug.LogWarning(stringBuilder.Append(prefix).Append(Log.nullReference));
            }
            #endif
        }

        /// <summary>
        /// Logs a warning message to the Unity console under a given context.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="context">The context of the message.</param>
        public static void Warning(object message, UnityEngine.Object context)
        {
            Warning(message, Log.prefix, context);
        }

        /// <summary>
        /// Logs a warning message to the Unity console with a custom prefix
        /// under a given context.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="prefix">The prefix of the message.</param>
        /// <param name="context">The context of the message.</param>
        public static void Warning(object message, string prefix, UnityEngine.Object context)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            stringBuilder.Clear();

            if (message != null) {
                UnityEngine.Debug.LogWarning(stringBuilder.Append(prefix).Append(message), context);
            } else {
                UnityEngine.Debug.LogWarning(stringBuilder.Append(prefix).Append(Log.nullReference), context);
            }
            #endif
        }

        /// <summary>
        /// Logs multiple warning messages as a single message to the Unity
        /// console.
        /// </summary>
        /// <param name="messages">The messages to log.</param>
        public static void Warning(params object[] messages)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            stringBuilder.Clear();
            stringBuilder.Append(Log.prefix);
            stringBuilder.Join(messages);
            UnityEngine.Debug.LogWarning(stringBuilder);
            #endif
        }

        /// <summary>
        /// Logs an error message to the Unity console.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Error(object message)
        {
            Error(message, Log.prefix);
        }

        /// <summary>
        /// Logs an error message to the Unity console with a custom prefix.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="prefix">The prefix of the message.</param>
        public static void Error(object message, string prefix)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            stringBuilder.Clear();

            if (message != null) {
                UnityEngine.Debug.LogError(stringBuilder.Append(prefix).Append(message));
            } else {
                UnityEngine.Debug.LogError(stringBuilder.Append(prefix).Append(Log.nullReference));
            }
            #endif
        }

        /// <summary>
        /// Logs an error message to the Unity console under a given context.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="context">The context of the message.</param>
        public static void Error(object message, UnityEngine.Object context)
        {
            Error(message, Log.prefix, context);
        }

        /// <summary>
        /// Logs an error message to the Unity console with a custom prefix
        /// under a given context.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="prefix">The prefix of the message.</param>
        /// <param name="context">The context of the message.</param>
        public static void Error(object message, string prefix, UnityEngine.Object context)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            stringBuilder.Clear();

            if (message != null) {
                UnityEngine.Debug.LogError(stringBuilder.Append(prefix).Append(message), context);
            } else {
                UnityEngine.Debug.LogError(stringBuilder.Append(prefix).Append(Log.nullReference), context);
            }
            #endif
        }

        /// <summary>
        /// Logs multiple error messages as a single message to the Unity
        /// console.
        /// </summary>
        /// <param name="messages">The messages to log.</param>
        public static void Error(params object[] messages)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            stringBuilder.Clear();
            stringBuilder.Append(Log.prefix);
            stringBuilder.Join(messages);
            UnityEngine.Debug.LogError(stringBuilder);
            #endif
        }

        /// <summary>
        /// Logs an assertion message to the Unity console.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Assertion(object message)
        {
            Assertion(message, Log.prefix);
        }

        /// <summary>
        /// Logs an assertion message to the Unity console with a custom prefix.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="prefix">The prefix of the message.</param>
        public static void Assertion(object message, string prefix)
        {
            #if UNITY_ASSERTIONS && (UNITY_EDITOR || DEVELOPMENT_BUILD)
            stringBuilder.Clear();

            if (message != null) {
                UnityEngine.Debug.LogAssertion(stringBuilder.Append(prefix).Append(message));
            } else {
                UnityEngine.Debug.LogAssertion(stringBuilder.Append(prefix).Append(Log.nullReference));
            }
            #endif
        }

        /// <summary>
        /// Logs an assertion message to the Unity console under a given context.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="context">The context of the message.</param>
        public static void Assertion(object message, UnityEngine.Object context)
        {
            Assertion(message, Log.prefix, context);
        }

        /// <summary>
        /// Logs an assertion message to the Unity console with a custom prefix
        /// under a given context.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="prefix">The prefix of the message.</param>
        /// <param name="context">The context of the message.</param>
        public static void Assertion(object message, string prefix, UnityEngine.Object context)
        {
            #if UNITY_ASSERTIONS && (UNITY_EDITOR || DEVELOPMENT_BUILD)
            stringBuilder.Clear();

            if (message != null) {
                UnityEngine.Debug.LogAssertion(stringBuilder.Append(prefix).Append(message), context);
            } else {
                UnityEngine.Debug.LogAssertion(stringBuilder.Append(prefix).Append(Log.nullReference), context);
            }
            #endif
        }

        /// <summary>
        /// Logs multiple assertion messages as a single message to the Unity
        /// console.
        /// </summary>
        /// <param name="messages">The messages to log.</param>
        public static void Assertion(params object[] messages)
        {
            #if UNITY_ASSERTIONS && (UNITY_EDITOR || DEVELOPMENT_BUILD)
            stringBuilder.Clear();
            stringBuilder.Append(Log.prefix);
            stringBuilder.Join(messages);
            UnityEngine.Debug.LogAssertion(stringBuilder);
            #endif
        }

        /// <summary>
        /// Joins multiple messages into a single message.
        /// </summary>
        private static void Join(this StringBuilder stringBuilder, object[] messages)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (messages == null)
            {
                stringBuilder.Append(Log.nullReference);
                return;
            }

            for (int i = 0; i < messages.Length - 1; i++)
            {
                object message = messages[i];

                if (message != null) {
                    stringBuilder.Append(message).Append(Log.delimiter);
                } else {
                    stringBuilder.Append(Log.nullReference).Append(Log.delimiter);
                }
            }

            if (messages.Length > 0)
            {
                object lastMessage = messages[messages.Length - 1];

                if (lastMessage != null) {
                    stringBuilder.Append(lastMessage);
                } else {
                    stringBuilder.Append(Log.nullReference);
                }
            }
            #endif
        }

    }

}
