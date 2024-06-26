using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FileTest))]
public class FileTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FileTest fileTest = target as FileTest;

        if(GUILayout.Button("Save"))
        {
            fileTest.Save();
        }

        if(GUILayout.Button("Load"))
        {
            fileTest.Load();
        }
    }
}
