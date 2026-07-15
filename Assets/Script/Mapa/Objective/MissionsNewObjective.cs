using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsNewObjective : MonoBehaviour
{

    //a ver, este lo tengo en duda, dado que casi prefiero más hacer objetivos individuales o formularlos de tal manera para que englobe varios,
    //a realmente hacer uno con muchos objetivos, porque en caso de, por ejemplo, necesitar una pausar porque a medias de la mision debes pillas 
    //un objeto, esta secuencia se rompe y debo crear otra.
    [Tooltip("Cumplir TODAS las misiones")]
    public int indexMod;

    [Header("Número de misiones que quieres que se cumplan")]
    //Esto lo hago para poder ocultar misiones secretas
    public int numMisionesCompletarTotal;

    [Header("What's Task")]
    public int taskWho;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);
            if (ObjectivesLevels.instanceObjectivesLevel.indexLine > taskWho) this.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (ListMissions.instanceMissions.numMissionsSuccess >= numMisionesCompletarTotal)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);
            if(ObjectivesLevels.instanceObjectivesLevel.indexLine > taskWho ) this.enabled = false;
        }
    }
}
