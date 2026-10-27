using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Delete_Items
{
    public void DeleteItems(List<GameObject> items)
    {
        foreach(GameObject item in items)
        {
            item.SetActive(false);
        }
    }
    public void ShowItems(List<GameObject> items)
    {
        foreach (GameObject item in items)
        {
            item.SetActive(true);
        }
    }
}
