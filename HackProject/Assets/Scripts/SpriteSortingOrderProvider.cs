using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteSortingOrderProvider
{
    public static int GetSortingOrder(GameObject gameObject)
    {
        var collider = gameObject.GetComponent<Collider2D>();
        var pivot = collider ? collider.bounds.center : gameObject.transform.position;

        var sortingOrder = -(int)(pivot.y * 100);
        return sortingOrder;
    }
}
