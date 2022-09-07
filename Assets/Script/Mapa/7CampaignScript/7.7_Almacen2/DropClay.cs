using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActivarModificador))]
[RequireComponent(typeof(PlayerHere))]
public class DropClay : MonoBehaviour
{
    public int indexMod;
    ActivarModificador activador;
    [Header("Electricity")]
    [SerializeField] Electrificacion electricity;
    [SerializeField] GameObject particleElectro;
    [Header("Clay Appear")]
    [SerializeField] GameObject clay;
    [Header("Events")]
    [SerializeField] Events events;
    bool goEvent;

    PlayerHere player;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) ClayCutElectricity();
    }

    // Update is called once per frame
    void Update()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) ActiveCutElectricity();
        ExecuteCutElectricity();
    }
    void ActiveCutElectricity()
    {
        //When player arrives to the zone that you can use the item, the action (ClayCutElectricity) subscribes to the event
        if (player.playerImHere)
        {
            events.actionOnCinematic += ClayCutElectricity;
            //When activate the modificacion script to begin event
            if (activador.modificacion)
            {
                goEvent = true;
            }
        }
        else
        {
            events.actionOnCinematic -= ClayCutElectricity;
        }
    }
    void ExecuteCutElectricity()
    {
        //Execute Event
        if (goEvent)
        {
            events.Cinematic(ref goEvent);
        }
    }
    void ClayCutElectricity()
    {
        //The action in event
        if (activador.modificacion)
        {
            //Destruir las particulas o hacerlas desaparecer
            Destroy(electricity);
            Destroy(particleElectro);
            clay.SetActive(true);
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
