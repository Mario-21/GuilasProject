using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class BotonDrenajeObstruido : MonoBehaviour
{
    public int indexMod;
    [SerializeField] EventReference sonidoObstruccion;
    Animator animBotonObstruido;
    PlayerHere playerHere;


    //El boton de obstruccion hace un sonido diferente al de normal, para marcar que esta obstrruido
    //A su vez, quiza le meto una animación que cuando lo presiones cambia a un color amarillo
    //Al desatascar el desague este escript y la animación se deshabilitaran
    //No se cambia el color del boton a uno grisaceo, el gris sirve para decir que algo no funciona
    private void Awake()
    {
        playerHere = GetComponent<PlayerHere>();
        animBotonObstruido = GetComponent<Animator>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            this.enabled = false;
            animBotonObstruido.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ObstruccionBoton();
        }
        else
        {
            animBotonObstruido.enabled = false;
        }
    }
    void ObstruccionBoton()
    {
        if (playerHere.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(sonidoObstruccion);
                animBotonObstruido.SetTrigger("Obstruccion_Press");
                //Encender animacion del boton
            }
        }
    }
}
