using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpriteGroup))]
public class SpriteGroupEditor : Editor
{
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		
		SpriteGroup tr = target as SpriteGroup;

		if (GUILayout.Button("Apply to children")) {
			tr.Apply();
		}
	}
}