#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Zigurous.Debug
{
    /// <summary>
    /// Pauses the application via user input.
    /// </summary>
    [AddComponentMenu("Zigurous/Debug/Pause Application")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.debug/api/Zigurous.Debug/PauseApplication")]
    public sealed class PauseApplication : MonoBehaviour
    {
        #if ENABLE_INPUT_SYSTEM
        /// <summary>
        /// The input action that pauses the application.
        /// </summary>
        [Tooltip("The input action that pauses the application.")]
        [Header("Input System")]
        public InputAction pauseInput = new("PauseApplication", InputActionType.Button, "<Keyboard>/pause");
        #endif

        #if ENABLE_LEGACY_INPUT_MANAGER
        /// <summary>
        /// The keycode that pauses the application.
        /// </summary>
        [Tooltip("The keycode that pauses the application.")]
        [Header("Legacy Input Manager")]
        public KeyCode pauseKey = KeyCode.Break;

        /// <summary>
        /// The optional modifier key to be held down to pause the application.
        /// </summary>
        [Tooltip("The optional modifier key to be held down to pause the application.")]
        public KeyCode pauseKeyModifier = KeyCode.None;
        #endif

        /// <summary>
        /// Whether the application is currently paused or not (Read only).
        /// </summary>
        #if UNITY_EDITOR
        public bool paused => EditorApplication.isPaused;
        #else
        public bool paused { get; private set; }
        #endif

        #if ENABLE_INPUT_SYSTEM
        private void Awake()
        {
            pauseInput.performed += OnPause;
        }

        private void OnDestroy()
        {
            pauseInput.Dispose();
        }

        private void OnEnable()
        {
            pauseInput.Enable();
        }

        private void OnDisable()
        {
            pauseInput.Disable();
        }

        private void OnPause(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (paused) {
                    Resume();
                } else {
                    Pause();
                }
            }
        }
        #endif

        #if ENABLE_LEGACY_INPUT_MANAGER
        private void Update()
        {
            if (Input.GetKeyDown(pauseKey))
            {
                if (pauseKeyModifier == KeyCode.None || Input.GetKey(pauseKeyModifier))
                {
                    if (paused) {
                        Resume();
                    } else {
                        Pause();
                    }
                }
            }
        }
        #endif

        /// <summary>
        /// Pauses the application.
        /// </summary>
        public void Pause()
        {
            #if UNITY_EDITOR
            EditorApplication.isPaused = true;
            #else
            paused = true;
            Time.timeScale = 0f;
            #endif
        }

        /// <summary>
        /// Resumes the application.
        /// </summary>
        public void Resume()
        {
            #if UNITY_EDITOR
            EditorApplication.isPaused = false;
            #else
            paused = false;
            Time.timeScale = 1f;
            #endif
        }

    }

}
