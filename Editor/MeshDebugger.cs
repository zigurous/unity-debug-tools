using UnityEditor;
using UnityEngine;

namespace Zigurous.Debug.Editor
{
    public sealed class MeshDebugger : EditorWindow
    {
        private Mesh currentMesh;
        private MeshFilter currentMeshFilter;
        private SkinnedMeshRenderer currentSkinnedMeshRenderer;
        private int currentFace = 0, numFaces = 0, newFace = 0;
        private GUIStyle labelStyle = null;
        private Vector3 p1, p2, p3;

        [MenuItem("Window/Analysis/Mesh Debugger")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(MeshDebugger), true, "Mesh Debugger");
        }

        private void OnEnable()
        {
            SceneView.duringSceneGui -= OnSceneGUI;
            SceneView.duringSceneGui += OnSceneGUI;

            OnSelectionChange();
        }

        private void OnDestroy()
        {
            SceneView.duringSceneGui -= OnSceneGUI;
        }

        private void OnSelectionChange()
        {
            currentMesh = null;
            currentSkinnedMeshRenderer = null;
            numFaces = 0;

            if (Selection.activeGameObject)
            {
                currentMeshFilter = Selection.activeGameObject.GetComponentInChildren<MeshFilter>();

                if (currentMeshFilter != null)
                {
                    currentMesh = currentMeshFilter.sharedMesh;
                    numFaces = currentMesh.triangles.Length / 3;
                }
                else
                {
                    currentSkinnedMeshRenderer = Selection.activeGameObject.GetComponentInChildren<SkinnedMeshRenderer>();

                    if (currentSkinnedMeshRenderer != null)
                    {
                        currentMesh = currentSkinnedMeshRenderer.sharedMesh;
                        numFaces = currentMesh.triangles.Length / 3;
                    }
                }
            }

            currentFace = 0;
            newFace = currentFace;

            Repaint();
        }

        private void OnGUI()
        {
            if (currentMesh == null)
            {
                EditorGUILayout.LabelField("Current selection contains no mesh");
                return;
            }

            EditorGUILayout.LabelField("Number of faces", numFaces.ToString());
            EditorGUILayout.LabelField("Current face", currentFace.ToString());

            newFace = EditorGUILayout.IntField("Jump to face", currentFace);

            if (newFace != currentFace)
            {
                if (newFace >= 0 && newFace < numFaces) {
                    currentFace = newFace;
                }
            }

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Previous Face"))
            {
                currentFace = (currentFace - 1) % numFaces;

                if (currentFace < 0) {
                    currentFace = currentFace + numFaces;
                }
            }

            if (GUILayout.Button("Next Face")) {
                currentFace = (currentFace + 1) % numFaces;
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            int redIndex = currentMesh.triangles[currentFace * 3];
            int greenIndex = currentMesh.triangles[currentFace * 3 + 1];
            int blueIndex = currentMesh.triangles[currentFace * 3 + 2];

            EditorGUILayout.LabelField("Red vertex", $"Index: {redIndex}, UV: ({currentMesh.uv[redIndex].x}, {currentMesh.uv[redIndex].y})");
            EditorGUILayout.LabelField("Green vertex", $"Index: {greenIndex}, UV: ({currentMesh.uv[greenIndex].x}, {currentMesh.uv[greenIndex].y})");
            EditorGUILayout.LabelField("Blue vertex", $"Index: {blueIndex}, UV: ({currentMesh.uv[blueIndex].x}, {currentMesh.uv[blueIndex].y})");
        }

        private void OnSceneGUI(SceneView sceneView)
        {
            if (currentMesh == null) {
                return;
            }

            int index1 = currentMesh.triangles[currentFace * 3];
            int index2 = currentMesh.triangles[currentFace * 3 + 1];
            int index3 = currentMesh.triangles[currentFace * 3 + 2];

            if (currentMeshFilter != null)
            {
                p1 = currentMeshFilter.transform.TransformPoint(currentMesh.vertices[index1]);
                p2 = currentMeshFilter.transform.TransformPoint(currentMesh.vertices[index2]);
                p3 = currentMeshFilter.transform.TransformPoint(currentMesh.vertices[index3]);
            }
            else if (currentSkinnedMeshRenderer != null)
            {
                p1 = currentSkinnedMeshRenderer.transform.TransformPoint(currentMesh.vertices[index1]);
                p2 = currentSkinnedMeshRenderer.transform.TransformPoint(currentMesh.vertices[index2]);
                p3 = currentSkinnedMeshRenderer.transform.TransformPoint(currentMesh.vertices[index3]);
            }

            Handles.color = Color.red;
            Handles.SphereHandleCap(0, p1, Quaternion.identity, 0.2f * HandleUtility.GetHandleSize(p1), EventType.Repaint);
            Handles.color = Color.green;
            Handles.SphereHandleCap(0, p2, Quaternion.identity, 0.2f * HandleUtility.GetHandleSize(p2), EventType.Repaint);
            Handles.color = Color.blue;
            Handles.SphereHandleCap(0, p3, Quaternion.identity, 0.2f * HandleUtility.GetHandleSize(p3), EventType.Repaint);

            Handles.color = Color.white;
            Handles.DrawDottedLine(p1, p2, 5f);
            Handles.DrawDottedLine(p2, p3, 5f);
            Handles.DrawDottedLine(p3, p1, 5f);

            if (labelStyle == null)
            {
                labelStyle = new GUIStyle(GUI.skin.label);
                labelStyle.normal.textColor = Color.white;
                labelStyle.fixedWidth = 40;
                labelStyle.fixedHeight = 20;
                labelStyle.alignment = TextAnchor.MiddleCenter;
                labelStyle.fontSize = 12;
                labelStyle.clipping = TextClipping.Overflow;
            }

            Handles.Label(p1, index1.ToString(), labelStyle);
            Handles.Label(p2, index2.ToString(), labelStyle);
            Handles.Label(p3, index3.ToString(), labelStyle);

            sceneView.Repaint();
        }

        private void OnInspectorUpdate()
        {
            Repaint();
        }

    }

}
