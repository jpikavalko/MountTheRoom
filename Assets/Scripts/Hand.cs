using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HAND { LEFT, RIGHT }
public class Hand : MonoBehaviour
{
    public LayerMask collisionLayers;
    public HAND hand;

    private GameObject itemInHand;
    private bool isTouching = false;

    private void OnTriggerEnter(Collider other)
    {
        isTouching = IsInLayerMask(other.gameObject.layer, collisionLayers);
        if (isTouching)
        {
            itemInHand = other.gameObject;
        }
        else
        {
            if (itemInHand != null) itemInHand.GetComponent<Collider>().enabled = true;
            itemInHand = null;
        }
    }

    private static bool IsInLayerMask(int layer, LayerMask layermask)
    {
        return layermask == (layermask | (1 << layer));
    }

    public GameObject GetItemInHand()
    {
        return itemInHand;   
    }
}
