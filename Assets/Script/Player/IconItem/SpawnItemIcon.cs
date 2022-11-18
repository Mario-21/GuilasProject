using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemIcon : MonoBehaviour
{
    [Header("Item Con Animacion")]
    public GameObject iconItem;
    [Header("Icon Item")]
    public Sprite iconPickUp;
    [Header("Spawn Icon")]
    public Transform iconeZone;
 
    public void SpawnIcon()
    {
        iconItem.GetComponent<SpriteRenderer>().sprite = iconPickUp;
        GameObject iconObjeto = Instantiate(iconItem, iconeZone.position, Quaternion.identity);
        iconObjeto.transform.parent = iconeZone.transform;
    }
}
