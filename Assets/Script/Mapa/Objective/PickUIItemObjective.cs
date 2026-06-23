using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUIItemObjective : MonoBehaviour
{
    public int indexMod;
    [Header("Index Item UI")]
    public int indexItemUI;
    [Header("What's Task")]
    public int taskWho;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);
            this.enabled = false;
        }
    }
    void Update()
    {
        PickItemsUIObjective();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);
            this.enabled = false;
        }
    }
    void PickItemsUIObjective()
    {
        //Copiar el TaskWhoIAm();
        if (ListaItemsUI.listaItemsUI.listaAllItemUI[indexItemUI].itemUICatch)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
