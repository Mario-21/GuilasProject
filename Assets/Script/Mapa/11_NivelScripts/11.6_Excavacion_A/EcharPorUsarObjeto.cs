using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcharPorUsarObjeto : MonoBehaviour
{
    public int indexMod;
    [Header("Tag del Objeto")]
    public string tagObjeto;
    bool objetoTrigger;
    [Header("Definir como quieres que se defina la soldado")]
    public DefinirEcharPorObjetoSoldado definirSoldado;
    public enum DefinirEcharPorObjetoSoldado
    {
        Index,
        NoIndex
    }
    [Header("Soldado Asignado Guardia")]
    [SerializeField] int indexSoldado;
    [SerializeField] SoldierLife soldadoVida;
    [SerializeField] SoldadoNormal soldadoStatus;
    [SerializeField] GameObject brazoNormal;
    [SerializeField] GameObject brazoAlerta;
    [Header("Echar Area")]
    [SerializeField] GameObject cambiarArea;
    [Header("Area del Trigger del Objeto")]
    [SerializeField] GameObject triggerObjeto;

    PlayerHere player;

    [Header("Comprobaciones")]
    public JugadorMovimiento playerMov;
    void Start()
    {
        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (definirSoldado)
        {
            case DefinirEcharPorObjetoSoldado.Index:
                SoldadoIndexEchar();
                break;
            case DefinirEcharPorObjetoSoldado.NoIndex:
                SoldadoNoIndexEchar();
                break;
        }
    }
    void SoldadoNoIndexEchar()
    {

        if (soldadoVida.vida > 0 && !soldadoStatus.berserker)
        {
            UsoObjetoIndebido_Echar();
            //Esto se hace para que puedas tener a varios enemigos en funcionamiento cuando vayas a realizar la acción
            triggerObjeto.SetActive(false);
        }
        else if (soldadoVida.vida <= 0 || StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            //Habilitar el poder usar el objeto
            triggerObjeto.SetActive(true);
            //Desactivar este script porque ya no lo necesitas
            this.enabled = false;

        }
    }
    void SoldadoIndexEchar()
    {
        if(SoldierActiveInScene.instancia.soldiersStatus[indexSoldado].statusVida > 0 && !SoldierActiveInScene.instancia.soldiersStatus[indexSoldado].berserkerStatus)
        {
            UsoObjetoIndebido_Echar();
            //Esto se hace para que puedas tener a varios enemigos en funcionamiento cuando vayas a realizar la acción
            triggerObjeto.SetActive(false);
        }
        else if (SoldierActiveInScene.instancia.soldiersStatus[indexSoldado].statusVida <= 0 || StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            //Habilitar el poder usar el objeto
            triggerObjeto.SetActive(true);
            //Desactivar este script porque ya no lo necesitas
            this.enabled = false;
        }
    }
    void UsoObjetoIndebido_Echar()
    {
        if (player.playerImHere && objetoTrigger)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                cambiarArea.SetActive(true);
                brazoNormal.SetActive(false);
                brazoAlerta.SetActive(true);
                SoldadoOrientacionEchar();
            }
        }
    }
    void SoldadoOrientacionEchar()
    {
        soldadoStatus.enabled = false;
        if (DistaciaPlayerSoldado().x < 0)
        {
            soldadoStatus.transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }
        else if(DistaciaPlayerSoldado().x > 0)
        {
            soldadoStatus.transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagObjeto)) objetoTrigger = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagObjeto)) objetoTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagObjeto)) objetoTrigger = false;
    }

    //[ContextMenu("Distacia Player Enemigo")]
    public Vector2 DistaciaPlayerSoldado()
    {
        Vector2 distancia;
        return distancia = playerMov.transform.position - soldadoStatus.transform.position;
        //Si la distancia es positivo = Jugador esta a la derecha
        //Si la distancia es negativo = Jugador esta a la Izquieda
    }
}
