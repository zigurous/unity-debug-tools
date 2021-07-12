using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Zigurous.Debug
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
        /// The text format of the framerate display.
        /// </summary>
        public string displayFormat { get; protected set; }

        /// <summary>
        /// The amount of seconds between display updates.
        /// </summary>
        [Tooltip("The amount of seconds between display updates.")]
        public float refreshRate = 1.0f;

        /// <summary>
        /// The time of the next framerate update.
        /// </summary>
        public float nextUpdate { get; private set; }

        /// <summary>
        /// The number of decimal digits to display.
        /// </summary>
        [Tooltip("The number of decimal digits to display.")]
        [SerializeField]
        private int _decimals = 0;

        /// <summary>
        /// The number of decimal digits to display.
        /// </summary>
        public int decimals
        {
            get => _decimals;
            set
            {
                _decimals = value;
                SetDisplayFormat(value);
            }
        }

        private void OnValidate()
        {
            SetDisplayFormat(this.decimals);
        }

        private void Awake()
        {
            SetDisplayFormat(this.decimals);
        }

        private void Update()
        {
            if (Time.unscaledTime > this.nextUpdate)
            {
                this.nextUpdate = Time.unscaledTime + this.refreshRate;
                float fps = 1.0f / Time.unscaledDeltaTime;
                UpdateDisplay(fps);
            }
        }

        /// <summary>
        /// Sets the text format of the framerate display.
        /// </summary>
        /// <param name="decimals">The number of decimal digits to display.</param>
        protected virtual void SetDisplayFormat(int decimals)
        {
            int length = 1 + decimals;
            if (decimals > 0) length++;

            StringBuilder stringBuilder = new StringBuilder(length);
            stringBuilder.Append('0');

            if (decimals > 0)
            {
                stringBuilder.Append('.');
                stringBuilder.Insert(2, "0", decimals);
            }

            this.displayFormat = stringBuilder.ToString();
        }

        /// <summary>
        /// Updates the display with the given framerate.
        /// </summary>
        /// <param name="fps">The framerate to display.</param>
        protected virtual void UpdateDisplay(float fps)
        {
            if (this.displayText != null) {
                this.displayText.text = fps.ToString(this.displayFormat);
            }
        }

    }

}
