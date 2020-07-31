using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class SpriteGroup : MonoBehaviour {
    public string sortingLayerName = "Default";
    public int sortingOrder;
    public bool dynamic = false;
    
    // Start is called before the first frame update
    void Start() {
        Apply();
    }

    public void Apply() {
        var sprites = GetComponentsInChildren<SpriteRenderer>();

        foreach (var sprite in sprites) {
            Undo.RegisterCompleteObjectUndo(sprite, "Apply sorting order");
            sprite.sortingLayerName = sortingLayerName;
            sprite.sortingOrder = sortingOrder;
        }
        
        Undo.FlushUndoRecordObjects();
    }

    public void Update()
    {
        if (!dynamic) return;

        Recalculate();
    }

    private void Recalculate()
    {
        sortingOrder = SpriteSortingOrderProvider.GetSortingOrder(gameObject);
        GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
        Apply();
    }
}
