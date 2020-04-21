using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class Generator : Editor {

	public override void OnInspectorGUI()
    {
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update ();
		DrawDefaultInspector();
		
		var map = (MapGenerator)this.target;
        // Show the custom GUI controls.
        if(GUILayout.Button("Generate"))
			map.Generate();

        if(GUILayout.Button("Clear"))
			map.RemoveObjects();

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties ();
    }
	
}
