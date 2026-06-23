    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsNewObjective : MonoBehaviour
{

    //a ver, este lo tengo en duda, dado que casi prefiero más hacer objetivos individuales o formularlos de tal manera para que englobe varios,
    //a realmente hacer uno con muchos objetivos, porque en caso de, por ejemplo, necesitar una pausar porque a medias de la mision debes pillas 
    //un objeto, esta secuencia se rompe y debo crear otra.

    public int indexMod;
    public List<int> indexMissions;

    public int missionsLimit;
    int missionsComplete;
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
        MissionsObjective();
        MissionsCompleteTask();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);
            this.enabled = false;
        }
    }
    void MissionsObjective()
    {
        //Copiar el TaskWhoIAm();
        for (int i = 0; i < indexMissions.Count; i++)
        {
            if (ListMissions.listaMissions.missionsMap[indexMissions[i]].success)
            {
                missionsComplete++;
                indexMissions.Remove(indexMissions[i]);
            }
        }
    }
    void MissionsCompleteTask()
    {
        if (missionsComplete >= missionsLimit)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
