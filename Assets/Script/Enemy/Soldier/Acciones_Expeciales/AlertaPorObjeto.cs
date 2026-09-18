using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertaPorObjeto : MonoBehaviour
{
    [Header("Condiciones Echar")]
    public int indexSleep;
    public int indexObjeto;
    [SerializeField] PutGasMask basketMask;
    PlayerHere player;
    [Header ("Definir Tipo de Alerta")]
    public TipoAlertar tipoDeAlerta;
    public enum TipoAlertar
    {
        Condicion_Mascara,
        Sin_Condicion
    }
    [Header("Cambiar Area")]
    [SerializeField] GameObject cambiarArea;
    [Header("Soldado Info")]
    [SerializeField] SoldadoNormal soldadoAlerta;
    [SerializeField] SoldierLife vidaSoldadoAlerta;
    [SerializeField] GameObject brazoNormal;
    [SerializeField] GameObject brazoAlerta;
    void Start()
    {
        //Cuando presiones el boton de accion con las condiciones requeridas incumplidas, aparecera un Cambio de Area, esta te echara de la zona a la vez que reproduce un audio del soldado y levanta la mano
        //acusandote.
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexSleep].modificacion) this.enabled = false;
    }
    void Update()
    {
        switch (tipoDeAlerta)
        {
            case TipoAlertar.Condicion_Mascara:
                EcharJugadorMascara();
                break;
            case TipoAlertar.Sin_Condicion:
                EcharJugadorNoCondicion();
                break;
        }
    }
    void EcharJugadorMascara()
    {
        //Si intentas coger el objeto, el tio, te echará de la zona
        //Como ha cambiado el modo Berserker y ahora se puede perder el estado pasado un tiempo, esto implica que se deba añadir la condición "si has obtenido el objeto", dado que al estar en modo
        //berserker si tienes la posibilidad de robar el objeto. Entonces, esto provoca que si yo añado esta condición me puede llamar la atención por no robar nada.
        if (!basketMask.putMask && vidaSoldadoAlerta.vida >= 1 && !soldadoAlerta.berserker && !SaveScene.instancia.listaItemsNivelGuardar[indexObjeto].objetoObtenido)
        {
            if (player.playerImHere && Input.GetButtonDown("Take"))
            {
                cambiarArea.SetActive(true);
                brazoNormal.SetActive(false);
                brazoAlerta.SetActive(true);
            }
        }
    }
    void EcharJugadorNoCondicion()
    {
        if (vidaSoldadoAlerta.vida >= 1 && !soldadoAlerta.berserker && !SaveScene.instancia.listaItemsNivelGuardar[indexObjeto].objetoObtenido)
        {
            if (player.playerImHere && Input.GetButtonDown("Take"))
            {
                cambiarArea.SetActive(true);
                brazoNormal.SetActive(false);
                brazoAlerta.SetActive(true);
            }
        }
    }
}
