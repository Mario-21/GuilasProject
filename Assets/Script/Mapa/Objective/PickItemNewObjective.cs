using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemNewObjective : MonoBehaviour
{
    
    public int indexMod;
    public int indexItem;
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

    // Update is called once per frame
    void Update()
    {
        PickItemsObjective();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);
            this.enabled = false;
        }
    }
    void PickItemsObjective()
    {
        //Copiar el TaskWhoIAm();
        if (SaveScene.instancia.listaItemsNivelGuardar[indexItem].objetoObtenido)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }

}
