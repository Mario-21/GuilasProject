using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPintura : MonoBehaviour
{
    /*Descripcion:
     * TriggerPintura sirve para una accion muy expecífica, la de poder cambiar una prenda de ropa (o lo que sea)
     * por otra, sin que conlleve que al realizar la acción te la coloques a la vez que se tinte. Realmente, solo
     * sirve para resolver un problema que solo ocurre con los objetos que intercambian ropa, dado que solo hay uno
     * en todo el compendio
    */
    public int index;
    [Header ("Pieza Ropa")]
    public BoxCollider2D triggerColliderRopa;
    bool entrarPlayer;

    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[index].modificacion)
        {
            triggerColliderRopa.enabled = false;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        EntrarSalirPintura();
    }
    void EntrarSalirPintura()
    {
        //En cuanto el jugador entre al trigger de la ropa debe desactivarse, todo esto con la condición de que el jugador NO haya cambiado de ropa previamente
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[index].modificacion)
        {
            //Si entra en el rango, el jugador desactiva el trigger para que no haya ningun error
            if (entrarPlayer)
            {
                triggerColliderRopa.enabled = false;
            }
            //En cuanto salé se vuelve a activar
            else
            {
                triggerColliderRopa.enabled = true;
            }
        }
        //En cuanto detecte que has realizado el intercambio de ropa, el trigger de ropa desaparecerá y este script se desactivará
        //Esto se hace para no estar constantemente activando y desactivando el trigger de la primera ropa, por si acaso induce a error
        else
        {
            //triggerPiezaRopa.SetActive(false);
            triggerColliderRopa.enabled = false;
            this.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log("El Player ha entrado a la pintura");
            entrarPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log("El Player ha salido de la pintura");
            entrarPlayer = false;
        }
    }
}
