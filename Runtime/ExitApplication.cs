using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Zigurous.Debug
{
    /// <summary>
    /// Quits the application via user input.
    /// </summary>
    [AddComponentMenu("Zigurous/Debug/Exit Application")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.debug/api/Zigurous.Debug/ExitApplication")]
    public sealed class ExitApplication : MonoBehaviour
    {
        #if ENABLE_INPUT_SYSTEM
        /// <summary>
        /// The input action that quits the application.
        /// </summary>
        [Tooltip("The input action that quits the application.")]
        [Header("Input System")]
        public InputAction quitInput = new("ExitApplication", InputActionType.Button, "<Keyboard>/escape");
        #endif

        #if ENABLE_LEGACY_INPUT_MANAGER
        /// <summary>
        /// The keycode that quits the application.
        /// </summary>
        [Tooltip("The keycode that quits the application.")]
        [Header("Legacy Input Manager")]
        public KeyCode quitKey = KeyCode.Escape;

        /// <summary>
        /// The optional modifier key to be held down to quit the application.
        /// </summary>
        [Tooltip("The optional modifier key to be held down to quit the application.")]
        public KeyCode quitKeyModifier = KeyCode.None;
        #endif

        #if ENABLE_INPUT_SYSTEM
        private void Awake()
        {
            quitInput.performed += OnQuit;
        }

        private void OnDestroy()
        {
            quitInput.Dispose();
        }

        private void OnEnable()
        {
            quitInput.Enable();
        }

        private void OnDisable()
        {
            quitInput.Disable();
        }

        private void OnQuit(InputAction.CallbackContext context)
        {
            if (context.performed) {
                Quit();
            }
        }
        #endif

        #if ENABLE_LEGACY_INPUT_MANAGER
        private void Update()
        {
            if (Input.GetKeyDown(quitKey))
            {
                if (quitKeyModifier == KeyCode.None || Input.GetKey(quitKeyModifier)) {
                    Quit();
                }
            }
        }
        #endif

        /// <summary>
        /// Quits the application, or exits playmode if running in the editor.
        /// </summary>
        public void Quit()
        {
            #if UNITY_EDITOR
            if (Application.isEditor)
            {
                UnityEditor.EditorApplication.ExitPlaymode();
                return;
            }
            #endif

            Application.Quit();
        }

    }

}
