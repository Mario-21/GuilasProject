using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItemNow : MonoBehaviour
{
    public int indexMod;

    public List<GameObject> itemsNow;
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            foreach (GameObject items in itemsNow)
            {
                items.SetActive(false);
            }
        }
    }
}
