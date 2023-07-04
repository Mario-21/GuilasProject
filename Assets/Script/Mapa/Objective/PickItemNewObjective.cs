using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemNewObjective : MonoBehaviour
{

    public int indexMod;
    public List<int> indexItems;

    public int itemPicksLimit;
    int itemsPicks;
    [Header("What's Task")]
    public int taskWho;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) WhoTaskIAmPickItems();
    }

    // Update is called once per frame
    void Update()
    {
        PickItemsObjective();
        CompleteTaskItem();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) WhoTaskIAmPickItems();
    }
    void PickItemsObjective()
    {
        //Copiar el TaskWhoIAm();
        for (int i = 0; i < indexItems.Count; i++)
        {
            if (SaveScene.instancia.listaItemsNivelGuardar[indexItems[i]].objetoObtenido)
            {
                itemsPicks++;
                indexItems.Remove(indexItems[i]);
            }
        }
    }
    void CompleteTaskItem()
    {
        if(itemsPicks >= itemPicksLimit)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
    void WhoTaskIAmPickItems()
    {
        if (MostrarTextObjectives.indexLine == taskWho)
        {
            MostrarTextObjectives.indexLine++;
            this.enabled = false;
        }
        else if (MostrarTextObjectives.indexLine > taskWho)
        {
            this.enabled = false;
        }
    }
}
