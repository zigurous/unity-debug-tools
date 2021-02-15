using System;
using UnityEngine;

namespace Zigurous.Debugging
{
    /// <summary>
    /// Measures the execution time of two functions with a given amount of
    /// iterations.
    /// </summary>
    public abstract class ComparePerformance : MonoBehaviour
    {
        /// <summary>
        /// The amount of times each function is executed.
        /// </summary>
        [Tooltip("The amount of times each function is executed.")]
        public int iterations = 1000000;

        /// <summary>
        /// Triggers the script to be executed again.
        /// </summary>
        [Tooltip("Triggers the script to be executed again.")]
        public bool execute = false;

        #if UNITY_EDITOR || DEVELOPMENT_BUILD
        private void Start()
        {
            Iterate();
        }

        private void Update()
        {
            if (this.execute) {
                Iterate();
            }
        }
        #endif

        public void Iterate()
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            Iterate(this.iterations);
            this.execute = false;
            #endif
        }

        public void Iterate(int iterations)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            float timeA = Iterate(iterations, TestA);
            float timeB = Iterate(iterations, TestB);

            UnityEngine.Debug.Log("[Performance]:" + timeA + " vs " + timeB);
            #endif
        }

        public float Iterate(int iterations, Action test)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            float startTime = Time.realtimeSinceStartup;

            for (int i = 0; i < iterations; i++) {
                test();
            }

            return Time.realtimeSinceStartup - startTime;
            #else
            return float.NaN;
            #endif
        }

        protected abstract void TestA();
        protected abstract void TestB();

    }

}
