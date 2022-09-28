using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClotheInsideBasket : MonoBehaviour
{
    public int indexMod;
    Image clothes;
    void Start()
    {
        clothes = GetComponent<Image>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            clothes.enabled = true;
        }
    }
}
