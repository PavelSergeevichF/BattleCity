using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CellView))]
public class CustomInsprctor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CellView cellView = (CellView)target;
        if(GUILayout.Button("Apply"))
        {
            cellView.Apply();
        }
    }
}
