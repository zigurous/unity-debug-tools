using UnityEngine;

namespace Zigurous.Debug
{
    /// <summary>
    /// Additional debug functions for drawing shapes.
    /// </summary>
    public static class Draw
    {
        /// <summary>
        /// The data representation of a 3D box.
        /// </summary>
        private struct Box3D
        {
            public Vector3 origin { get; private set; }

            public Vector3 localFrontTopLeft { get; private set; }
            public Vector3 localFrontTopRight { get; private set; }
            public Vector3 localFrontBottomLeft { get; private set; }
            public Vector3 localFrontBottomRight { get; private set; }

            public Vector3 localBackTopLeft => -localFrontBottomRight;
            public Vector3 localBackTopRight => -localFrontBottomLeft;
            public Vector3 localBackBottomLeft => -localFrontTopRight;
            public Vector3 localBackBottomRight => -localFrontTopLeft;

            public Vector3 frontTopLeft => localFrontTopLeft + origin;
            public Vector3 frontTopRight => localFrontTopRight + origin;
            public Vector3 frontBottomLeft => localFrontBottomLeft + origin;
            public Vector3 frontBottomRight => localFrontBottomRight + origin;

            public Vector3 backTopLeft => localBackTopLeft + origin;
            public Vector3 backTopRight => localBackTopRight + origin;
            public Vector3 backBottomLeft => localBackBottomLeft + origin;
            public Vector3 backBottomRight => localBackBottomRight + origin;

            /// <summary>
            /// Creates a new box with a specified origin and size.
            /// </summary>
            /// <param name="origin">The origin of the box.</param>
            /// <param name="halfExtents">Half the size of the box in each dimension.</param>
            public Box3D(Vector3 origin, Vector3 halfExtents)
            {
                this.origin = origin;
                this.localFrontTopLeft = new Vector3(-halfExtents.x, halfExtents.y, -halfExtents.z);
                this.localFrontTopRight = new Vector3(halfExtents.x, halfExtents.y, -halfExtents.z);
                this.localFrontBottomLeft = new Vector3(-halfExtents.x, -halfExtents.y, -halfExtents.z);
                this.localFrontBottomRight = new Vector3(halfExtents.x, -halfExtents.y, -halfExtents.z);
            }

            /// <summary>
            /// Creates a new box with a specified origin, size, and rotation.
            /// </summary>
            /// <param name="origin">The origin of the box.</param>
            /// <param name="halfExtents">Half the size of the box in each dimension.</param>
            /// <param name="orientation">The orientation of the box.</param>
            public Box3D(Vector3 origin, Vector3 halfExtents, Quaternion orientation)
                : this(origin, halfExtents)
            {
                Rotate(orientation);
            }

            /// <summary>
            /// Rotates the box to the specified orientation.
            /// </summary>
            /// <param name="orientation">The orientation to rotate the box to.</param>
            public void Rotate(Quaternion orientation)
            {
                localFrontTopLeft = RotatePointAroundPivot(localFrontTopLeft, Vector3.zero, orientation);
                localFrontTopRight = RotatePointAroundPivot(localFrontTopRight, Vector3.zero, orientation);
                localFrontBottomLeft = RotatePointAroundPivot(localFrontBottomLeft, Vector3.zero, orientation);
                localFrontBottomRight = RotatePointAroundPivot(localFrontBottomRight, Vector3.zero, orientation);
            }

            /// <summary>
            /// Rotates a point around a pivot.
            /// </summary>
            /// <param name="point">The point to rotate.</param>
            /// <param name="pivot">The pivot to rotate around.</param>
            /// <param name="orientation">The orientation to rotate the point to.</param>
            /// <returns>The rotated point.</returns>
            private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion orientation)
            {
                Vector3 direction = point - pivot;
                return pivot + orientation * direction;
            }

            /// <summary>
            /// Draws the box with a given color.
            /// </summary>
            /// <param name="color">The color to draw the box with.</param>
            public void Draw(Color color)
            {
                #if UNITY_EDITOR || DEVELOPMENT_BUILD
                UnityEngine.Debug.DrawLine(frontTopLeft, frontTopRight, color);
                UnityEngine.Debug.DrawLine(frontTopRight, frontBottomRight, color);
                UnityEngine.Debug.DrawLine(frontBottomRight, frontBottomLeft, color);
                UnityEngine.Debug.DrawLine(frontBottomLeft, frontTopLeft, color);

                UnityEngine.Debug.DrawLine(backTopLeft, backTopRight, color);
                UnityEngine.Debug.DrawLine(backTopRight, backBottomRight, color);
                UnityEngine.Debug.DrawLine(backBottomRight, backBottomLeft, color);
                UnityEngine.Debug.DrawLine(backBottomLeft, backTopLeft, color);

                UnityEngine.Debug.DrawLine(frontTopLeft, backTopLeft, color);
                UnityEngine.Debug.DrawLine(frontTopRight, backTopRight, color);
                UnityEngine.Debug.DrawLine(frontBottomRight, backBottomRight, color);
                UnityEngine.Debug.DrawLine(frontBottomLeft, backBottomLeft, color);
                #endif
            }

        }

        /// <summary>
        /// Draws a wireframe box at a given position, scale, and rotation.
        /// </summary>
        /// <param name="position">The position of the box.</param>
        /// <param name="scale">The scale of the box.</param>
        /// <param name="rotation">The rotation of the box.</param>
        /// <param name="color">The color of the box.</param>
        public static void Box(Vector3 position, Vector3 scale, Quaternion rotation, Color color)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            new Box3D(position, scale / 2f, rotation).Draw(color);
            #endif
        }

        /// <summary>
        /// Draws a wireframe box using the same parameters as Physics.BoxCast.
        /// </summary>
        /// <param name="center">The center of the box.</param>
        /// <param name="halfExtents">Half the size of the box in each dimension.</param>
        /// <param name="direction">The direction in which to cast the box.</param>
        /// <param name="orientation">The rotation of the box.</param>
        /// <param name="distance">The length of the cast.</param>
        /// <param name="color">The color of the box.</param>
        public static void BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float distance, Color color)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            center += (direction.normalized * distance);
            Box(center, halfExtents, orientation, color);
            #endif
        }

    }

}
