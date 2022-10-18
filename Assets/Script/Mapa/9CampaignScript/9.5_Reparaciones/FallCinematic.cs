using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCinematic : MonoBehaviour
{
    public string tagName;
    
    public int indexMod;
    public int sceneCin;

    [SerializeField] BloquearMovimientoPlayer playerMov;

    bool fall;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagName))
        {
            //Cambiar al Update
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
            EstructuraNiveles.nivel = sceneCin;
            playerMov.BloquearMovPlayer();
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }

}
