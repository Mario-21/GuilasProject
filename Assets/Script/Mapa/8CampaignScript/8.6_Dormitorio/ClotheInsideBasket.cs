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
        //El falso se usa principalmente para los momentos en los que el personaje se esconde, de esta manera, la ropa
        //no aparece repentinamente sin que tu la hayas cogido previamente
        else
        {
            clothes.enabled = false;
        }
    }
}
