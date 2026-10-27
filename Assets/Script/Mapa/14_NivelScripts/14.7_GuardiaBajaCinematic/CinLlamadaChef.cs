using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class CinLlamadaChef : MonoBehaviour
{
    public int indexMod;

    public Animator detectar_Echar;
    [SerializeField] EventReference cogerTelefono;
    [SerializeField] GameObject soldadoChef;
    [SerializeField] GameObject telefonoCabinaObjeto;
    [SerializeField] Animator telefonoCabina;

    [Header("Tiempo entre escena")]
    [SerializeField] float tiempoEscena;
    [SerializeField] float tiempoEscenaLlamar;
    [SerializeField] float tiempoEscenaCorte;
    [SerializeField] float tiempoEscenaCogerTelefono;

    [Header("Orden de Escena")]
    public OrdenSecuencia ordenSecuencia;
    public enum OrdenSecuencia
    {
        PasarSecuencia,
        Llamar_Chef,
        Corte_Negro,
        Coger_Telefono,
        Final
    }

    [Header("Finalizar Secuencia")]
    [SerializeField] GameObject cambiarArea;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
        telefonoCabina.SetBool("Cabina_Call", true);
        ordenSecuencia = OrdenSecuencia.Llamar_Chef;
    }

    // Update is called once per frame
    void Update()
    {
        switch (ordenSecuencia)
        {
            case OrdenSecuencia.PasarSecuencia:
                break;
            case OrdenSecuencia.Llamar_Chef:
                //Mostrar el telefono Sonando
                ContenidoSecuencia(tiempoEscenaLlamar, true, OrdenSecuencia.Corte_Negro, AccionEspera);
                break;
            case OrdenSecuencia.Corte_Negro:
                ContenidoSecuencia(tiempoEscenaCorte, false, OrdenSecuencia.Coger_Telefono, CogerTelefonoSecuencia);
                break;
            case OrdenSecuencia.Coger_Telefono:
                ContenidoSecuencia(tiempoEscenaCogerTelefono, false, OrdenSecuencia.Final, AccionEspera);
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                break;
            case OrdenSecuencia.Final:
                
                cambiarArea.SetActive(true);
                break;
        }
        //Entras en escena
        //Ves el telefono sonando
        //Detectar echar en negro
        //Ves al chef coger telefono

    }
    void ContenidoSecuencia(float limite, bool estadoTransicion, OrdenSecuencia ordenS, Action accion = null)
    {
        if (tiempoEscena >= limite)
        {
            accion();
            detectar_Echar.SetBool("Transicion", estadoTransicion);
            ordenSecuencia = ordenS;
            tiempoEscena = 0;
        }
        else
        {
            tiempoEscena += Time.deltaTime;
        }
    }
    void CogerTelefonoSecuencia()
    {
        //Coger Telefono
        AudioManager.instancia.PlayOneShot(cogerTelefono);
        //Se hace presente el chef
        soldadoChef.SetActive(true);
        //El telefono que suena en la cabina desaparece
        telefonoCabinaObjeto.SetActive(false);
    }
    void AccionEspera()
    {
        //Esto solo sirve para rellenar y que en la primera parte no haga nada
    }
    //Inicio llamada
}
