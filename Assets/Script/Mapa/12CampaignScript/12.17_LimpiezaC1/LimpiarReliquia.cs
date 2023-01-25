using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    bool beginEvent;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = true;
            CleanReliquia();
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
            if (Input.GetKeyDown(KeyCode.Z))
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
        Show_Delete_Items cleanShowItem = new Show_Delete_Items();

        cleanShowItem.ShowItems(cleanItem);
        cleanShowItem.DeleteItems(rawItem);

        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
    }
    private void OnDisable()
    {
        events.actionOnCinematic -= CleanReliquia;
    }
}
