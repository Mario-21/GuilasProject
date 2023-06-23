using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNewObjective : MonoBehaviour
{
    public int indexMod;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Colocar la variable para que no me vaya incrementando constantemente el index
            if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
            {
                //Salta la animacion de la nueva nota.
                MostrarTextObjectives.indexPosImageMask++;
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            }
            
            

        }
    }
}
