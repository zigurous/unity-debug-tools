using UnityEngine;
using UnityEngine.UI;

namespace Zigurous.DebugTools
{
    /// <summary>
    /// Displays the framerate of the application in realtime.
    /// </summary>
    [AddComponentMenu("Zigurous/Debug/FPS Display")]
    public class FPSDisplay : MonoBehaviour
    {
        /// <summary>
        /// The UI text that display the framerate.
        /// </summary>
        [Tooltip("The UI text that display the framerate.")]
        public Text displayText;

        /// <summary>
        /// How often per second the framerate display updates.
        /// </summary>
        [Tooltip("How often per second the framerate display updates.")]
        public float refreshRate = 1.0f;

        /// <summary>
        /// The time of the next framerate update.
        /// </summary>
        protected float _nextUpdate;

        private void Update()
        {
            if (Time.unscaledTime > _nextUpdate)
            {
                int fps = (int)(1.0f / Time.unscaledDeltaTime);
                UpdateDisplay(fps);
                _nextUpdate = Time.unscaledTime + this.refreshRate;
            }
        }

        protected virtual void UpdateDisplay(int fps)
        {
            if (this.displayText != null) {
                this.displayText.text = fps.ToString();
            }
        }

    }

}
