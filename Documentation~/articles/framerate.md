---
slug: "/manual/framerate"
---

# Framerate Display

The **Debug Tools** package comes with a script and prefab to display the framerate of the game in realtime. This can be useful if you need to know the framerate outside of the Unity editor.

<hr/>

## 📟 Prefab

Simply drag the `FPSDisplay.prefab` into your scene, and you are done! It already comes pre-formatted and is contained within its own UI canvas. You can further customize the display to your liking. By default it is displayed in the top-right corner with zero decimal digits.

<hr/>

## 📺 Custom

You can also create your own display if you prefer and add the [FPSDisplay](/api/Zigurous.Debug/FPSDisplay) script to it manually. The script allows you to customize the number of decimal digits to display and how often you want it to refresh. At the minimum, you must pass a reference to a UI Text component that displays the framerate.
