using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteSortingOrderProvider
{
    public static int GetSortingOrder(SpriteRenderer renderer)
    {
        var collider = renderer.GetComponent<Collider2D>();
        var pivot = collider ? collider.bounds.center : renderer.transform.position;

        var sortingOrder = -(int)(pivot.y * 100);
        return sortingOrder;
    }
}
