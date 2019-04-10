using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class SpriteRenderOrder : MonoBehaviour {
	public bool runOnStart;
	private void Start() {
		if (runOnStart) {
			SortByY("Default");
			ApplySpriteGroups("Default");
		}
	}

	public void SortByY(string layerName) {
		SpriteRenderer[] sprites = FindObjectsOfType<SpriteRenderer>();
		foreach (var sprite in sprites) {
			bool isInLayer = sprite.sortingLayerName == layerName;
			if (isInLayer) {
				Undo.RegisterCompleteObjectUndo(sprite.transform, "SortByY");
				sprite.sortingOrder = -(int)(sprite.transform.position.y * 100);
			}
		}
		
		SpriteGroup[] groups = FindObjectsOfType<SpriteGroup>();

		foreach (var group in groups) {
			bool isInLayer = group.sortingLayerName == layerName;
			if (isInLayer) {
				Undo.RegisterCompleteObjectUndo(group, "SortByY");
				group.sortingOrder = -(int)(group.transform.position.y * 100);
			}
		}

		Undo.FlushUndoRecordObjects();
	}

	public void ApplySpriteGroups(string layerName) {
		SpriteGroup[] groups = FindObjectsOfType<SpriteGroup>();

		foreach (var group in groups) {
			bool isInLayer = group.sortingLayerName == layerName;
			if (isInLayer) {
				Undo.RegisterCompleteObjectUndo(group, "Apply sprite groups");
				group.Apply();
			}
		}

		Undo.FlushUndoRecordObjects();
	}
}
