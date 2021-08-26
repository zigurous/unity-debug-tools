using System;

namespace Zigurous.Debug
{
    /// <summary>
    /// Compares how many results are equal between two functions.
    /// </summary>
    /// <typeparam name="T">The type of value to compare.</typeparam>
    public static class Compare<T> where T: IEquatable<T>
    {
        /// <summary>
        /// Tests the equality of the results of two functions with a given
        /// amount of iterations.
        /// </summary>
        /// <param name="foo">The first function to execute.</param>
        /// <param name="bar">The second function to execute.</param>
        /// <param name="iterations">The amount of times each function is executed.</param>
        /// <param name="log">Logs the final comparison result.</param>
        /// <param name="logIndividual">Logs the result of each iteration of the functions.</param>
        /// <returns>The percentage of equal results.</returns>
        public static float Test(Func<T> foo, Func<T> bar, int iterations, bool log = true, bool logIndividual = false)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            int amountEqual = 0;

            for (int i = 0; i < iterations; i++)
            {
                T resultFoo = foo();
                T resultBar = bar();

                bool equal = resultFoo.Equals(resultBar);
                if (equal) amountEqual++;

                if (log && logIndividual) {
                    UnityEngine.Debug.Log($"[Compare]: {resultFoo.ToString()} vs {resultBar.ToString()} | {(equal ? "Equal" : "Not Equal")}");
                }
            }

            float percentEqual = (float)amountEqual / (float)iterations;

            if (log) {
                UnityEngine.Debug.Log($"[Compare]: {amountEqual.ToString()}/{iterations.ToString()} ({(percentEqual * 100.0f).ToString()}%) equal results");
            }

            return percentEqual;
            #else
            return float.NaN;
            #endif
        }

    }

}
