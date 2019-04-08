
using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpriteRenderOrder))]
public class SpriteSortEditor : Editor {
	private string layerName;
	
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		SpriteRenderOrder targ = (SpriteRenderOrder) target;

		layerName = EditorGUILayout.TextField("Layer Name", "1");

		if (GUILayout.Button("Sort")) {
			targ.SortByY(layerName);
		}
	}
}
