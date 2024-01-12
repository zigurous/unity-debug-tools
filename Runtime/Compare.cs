using System;

namespace Zigurous.Debug
{
    /// <summary>
    /// Compares the results of multiple functions for equality.
    /// </summary>
    public static class Compare
    {
        /// <summary>
        /// Compares how many results of the two functions are equal for a given
        /// amount of iterations.
        /// </summary>
        /// <param name="foo">The first function to execute.</param>
        /// <param name="bar">The second function to execute.</param>
        /// <param name="iterations">The amount of times each function is executed.</param>
        /// <param name="log">Logs the final comparison result.</param>
        /// <param name="logIndividual">Logs the result of each iteration of the functions.</param>
        /// <returns>The percentage of equal results.</returns>
        public static float Equal<T>(Func<T> foo, Func<T> bar, int iterations, bool log = true, bool logIndividual = false)
             where T : IEquatable<T>
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            int amountEqual = 0;

            for (int i = 0; i < iterations; i++)
            {
                T resultFoo = foo();
                T resultBar = bar();

                bool equal = resultFoo.Equals(resultBar);

                if (equal) {
                    amountEqual++;
                }

                if (log && logIndividual) {
                    UnityEngine.Debug.Log($"[Compare] {resultFoo.ToString()} vs {resultBar.ToString()} | {(equal ? "Equal" : "Not Equal")}");
                }
            }

            float percentEqual = amountEqual / (float)iterations;

            if (log) {
                UnityEngine.Debug.Log($"[Compare] {amountEqual.ToString()}/{iterations.ToString()} ({(percentEqual * 100f).ToString()}%) equal results");
            }

            return percentEqual;
            #else
            return float.NaN;
            #endif
        }

        /// <summary>
        /// Compares how many results of the two functions are not equal for a
        /// given amount of iterations.
        /// </summary>
        /// <param name="foo">The first function to execute.</param>
        /// <param name="bar">The second function to execute.</param>
        /// <param name="iterations">The amount of times each function is executed.</param>
        /// <param name="log">Logs the final comparison result.</param>
        /// <param name="logIndividual">Logs the result of each iteration of the functions.</param>
        /// <returns>The percentage of equal results.</returns>
        public static float NotEqual<T>(Func<T> foo, Func<T> bar, int iterations, bool log = true, bool logIndividual = false)
             where T : IEquatable<T>
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            int amountNotEqual = 0;

            for (int i = 0; i < iterations; i++)
            {
                T resultFoo = foo();
                T resultBar = bar();

                bool equal = resultFoo.Equals(resultBar);

                if (!equal) {
                    amountNotEqual++;
                }

                if (log && logIndividual) {
                    UnityEngine.Debug.Log($"[Compare] {resultFoo.ToString()} vs {resultBar.ToString()} | {(equal ? "Equal" : "Not Equal")}");
                }
            }

            float percentNotEqual = amountNotEqual / (float)iterations;

            if (log) {
                UnityEngine.Debug.Log($"[Compare] {amountNotEqual.ToString()}/{iterations.ToString()} ({(percentNotEqual * 100f).ToString()}%) not equal results");
            }

            return percentNotEqual;
            #else
            return float.NaN;
            #endif
        }

    }

}
