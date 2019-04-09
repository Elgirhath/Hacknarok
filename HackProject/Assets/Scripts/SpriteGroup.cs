using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpriteGroup : MonoBehaviour {
    public string sortingLayerName = "Default";
    public int sortingOrder;
    
    // Start is called before the first frame update
    void Start() {
        Apply();
    }

    public void Apply() {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();

        foreach (var sprite in sprites) {
            Undo.RegisterCompleteObjectUndo(sprite, "Apply sorting order");
            sprite.sortingLayerName = sortingLayerName;
            sprite.sortingOrder = sortingOrder;
        }
        
        Undo.FlushUndoRecordObjects();
    }
}
