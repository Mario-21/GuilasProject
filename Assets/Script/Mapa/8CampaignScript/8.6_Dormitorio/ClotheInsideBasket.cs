using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClotheInsideBasket : MonoBehaviour
{
    public int indexMod;
    SpriteRenderer clothes;
    private void Start()
    {
        clothes = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            clothes.enabled = true;
        }
    }
}
