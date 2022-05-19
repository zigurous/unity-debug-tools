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
        public string displayFormat { get; set; }

        /// <summary>
        /// The amount of seconds between display updates.
        /// </summary>
        [Tooltip("The amount of seconds between display updates.")]
        public float refreshRate = 0.125f;

        /// <summary>
        /// The time of the next framerate update.
        /// </summary>
        private float nextUpdate;

        [SerializeField]
        [Tooltip("The number of decimal digits to display.")]
        private int m_Decimals = 0;

        /// <summary>
        /// The number of decimal digits to display.
        /// </summary>
        public int decimals
        {
            get => m_Decimals;
            set
            {
                m_Decimals = value;
                SetDisplayFormat(value);
            }
        }

        private void Reset()
        {
            displayText = GetComponentInChildren<Text>();
        }

        private void OnValidate()
        {
            SetDisplayFormat(decimals);
        }

        private void Awake()
        {
            SetDisplayFormat(decimals);
        }

        private void Update()
        {
            if (Time.unscaledTime > nextUpdate)
            {
                nextUpdate = Time.unscaledTime + refreshRate;
                float fps = 1f / Time.unscaledDeltaTime;
                UpdateDisplay(fps);
            }
        }

        /// <summary>
        /// Updates the display with the given framerate.
        /// </summary>
        /// <param name="fps">The framerate to display.</param>
        protected virtual void UpdateDisplay(float fps)
        {
            if (displayText != null) {
                displayText.text = fps.ToString(displayFormat);
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

            displayFormat = stringBuilder.ToString();
        }

    }

}
