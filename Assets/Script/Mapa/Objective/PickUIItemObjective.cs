using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUIItemObjective : MonoBehaviour
{
    public int indexMod;
    public List<int> indexItemsUI;

    public int itemPicksLimit;
    int itemsPicks;
    [Header("What's Task")]
    public int taskWho;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) WhoTaskIAmPickItemsUI();
    }
    void Update()
    {
        PickItemsUIObjective();
        CompleteTaskItemUI();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) WhoTaskIAmPickItemsUI();
    }
    void PickItemsUIObjective()
    {
        //Copiar el TaskWhoIAm();
        for (int i = 0; i < indexItemsUI.Count; i++)
        {
            if (ListaItemsUI.listaItemsUI.listaAllItemUI[indexItemsUI[i]].itemUICatch)
            {
                itemsPicks++;
                indexItemsUI.Remove(indexItemsUI[i]);
            }
        }
    }
    void CompleteTaskItemUI()
    {
        if (itemsPicks >= itemPicksLimit)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
    void WhoTaskIAmPickItemsUI()
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
