using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class LimpiarReliquia : MonoBehaviour
{
    public int indexMod;
    [Header("Player")]
    [SerializeField] PlayerHere player;
    [Header("Evento")]
    [SerializeField] Events events;
    [Header("Item Clean")]
    public List<GameObject> cleanItem;
    [Header ("Item Raw")]
    public List<GameObject> rawItem;
    [Header("Sfx Limpiar")]
    [SerializeField] EventReference sfxClean;
    int cleanSound;
    bool beginEvent;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = true;
            show_Delete_Items().ShowItems(cleanItem);
            show_Delete_Items().DeleteItems(rawItem);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ActiveClean();
        }
        ExecuteClean();
    }
    void ActiveClean()
    {
        if (player.playerImHere)
        {
            events.actionOnCinematic += CleanReliquia;
            //evento.actionOnCinematic += Unearth;
            if (Input.GetButtonDown("Action"))
            {
                beginEvent = true;
            }
        }
    }
    void ExecuteClean()
    {
        if (beginEvent)
        {
            events.Cinematic(ref beginEvent);
        }
    }
    void CleanReliquia()
    {

        show_Delete_Items().ShowItems(cleanItem);
        show_Delete_Items().DeleteItems(rawItem);
        //cleanShowItem.ShowItems(cleanItem);
        //cleanShowItem.DeleteItems(rawItem);

        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;

        if (cleanSound < 1)
        {
            AudioManager.instancia.PlayOneShot(sfxClean);
            cleanSound++;
        }
    }
    private void OnDisable()
    {
        events.actionOnCinematic -= CleanReliquia;
    }
    public Show_Delete_Items show_Delete_Items()
    {
        Show_Delete_Items cleanShowItem = new Show_Delete_Items();
        return cleanShowItem;
    }
}
