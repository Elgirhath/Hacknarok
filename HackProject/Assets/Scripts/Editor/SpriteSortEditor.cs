
using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpriteRenderOrder))]
public class SpriteSortEditor : Editor {
	private string layerName;
	
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		SpriteRenderOrder targ = (SpriteRenderOrder) target;

		layerName = EditorGUILayout.TextField("Layer Name", "Default");

		if (GUILayout.Button("Sort")) {
			targ.SortByY(layerName);
		}
		
		if (GUILayout.Button("Apply sprite groups")) {
			targ.ApplySpriteGroups(layerName);
		}
	}
}
