using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActivarModificador))]
public class AbrirCofre : MonoBehaviour
{
    public int indexMod;
    [SerializeField] ActivarModificador activar;
    SpriteRenderer spriteActual;
    [SerializeField] Sprite chestOpen;
    [SerializeField] GameObject itemTake;

    int once;
    private void Awake()
    {
        activar = GetComponent<ActivarModificador>();
        spriteActual = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            spriteActual.sprite = chestOpen;
            itemTake.SetActive(true);
            activar.enabled = false;
        }
    }

    void Update()
    {
        //Cambia el Sprite para simular que algo se ha abierto  
        if (activar.modificacion) 
        {
            spriteActual.sprite = chestOpen;
            //Para que esta acción de aparecer no predomine sobre la del item
            if (once < 1) 
            {
                itemTake.SetActive(true);
                once++;
            }
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            activar.enabled = false;
        }
    }
}
