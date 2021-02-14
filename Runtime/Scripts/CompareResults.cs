using System;
using UnityEngine;

namespace Zigurous.Debugging
{
    public abstract class CompareResults<T> : MonoBehaviour where T: IEquatable<T>
    {
        public int iterations = 100;
        public bool printIndividualResults = false;
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
            Iterate(iterations, TestA, TestB);
            #endif
        }

        public void Iterate(int iterations, Func<T> a, Func<T> b)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            int amountEqual = 0;

            for (int i = 0; i < iterations; i++)
            {
                T resultA = a();
                T resultB = b();

                bool equal = resultA.Equals(resultB);
                if (equal) amountEqual++;

                if (printIndividualResults) {
                    UnityEngine.Debug.Log($"[Compare]: {resultA} vs {resultB} | {(equal ? "Equal" : "Not Equal")}");
                }
            }

            UnityEngine.Debug.Log($"[Compare]: {amountEqual} ({(float)amountEqual / (float)iterations * 100.0f}%) equal results");
            #endif
        }

        protected abstract T TestA();
        protected abstract T TestB();

    }

}
