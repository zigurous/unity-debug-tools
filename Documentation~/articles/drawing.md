---
slug: "/manual/drawing"
---

# Drawing

The **Debug Tools** package includes additional functions for drawing debug information similar to Unity's `Debug.DrawLine` and `Debug.DrawRay` functions. Specifically, the package provides functions to draw wireframe boxes.

<hr/>

## 📦 Box

Draws a wireframe box at a given position, scale, and rotation. This can be used to visualize the bounding box of an object.

```csharp
Draw.Box(transform.position, transform.localScale, transform.rotation, Color.green);
```

<hr/>

## 📤 BoxCast

Draws a wireframe box using the same parameters as `Physics.BoxCast`. This can be used to visualize a boxcast from one point to another.

```csharp
Draw.BoxCast(transform.position, transform.localScale / 2f, transform.forward, transform.rotation, 10f, Color.blue);
```
