using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class SpriteRenderOrder : MonoBehaviour
{
	public void SortByY(string layerName) {
		SpriteRenderer[] sprites = FindObjectsOfType<SpriteRenderer>();
//		Undo.RecordObjects(Array.ConvertAll(sprites, new Converter<SpriteRenderer,Object>(item => (Object) item)), "SortByY");
		foreach (var sprite in sprites) {
			bool isInLayer = sprite.sortingLayerName == layerName;
			if (isInLayer) {
				Undo.RegisterCompleteObjectUndo(sprite.transform, "SortByY");
				Transform tr = sprite.transform;
				Vector3 pos = sprite.transform.position; //TODO use this
				tr.position = new Vector3(tr.position.x, tr.position.y, tr.TransformPoint(tr.position).y);
			}
		}

		Undo.FlushUndoRecordObjects();
	}
}
