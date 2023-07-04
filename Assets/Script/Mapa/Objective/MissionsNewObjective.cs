    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsNewObjective : MonoBehaviour
{

    public int indexMod;
    public List<int> indexMissions;

    public int missionsLimit;
    int missionsComplete;
    [Header("What's Task")]
    public int taskWho;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) WhoTaskMissionComplete();
    }

    // Update is called once per frame
    void Update()
    {
        MissionsObjective();
        MissionsCompleteTask();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) WhoTaskMissionComplete();
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
    void WhoTaskMissionComplete()
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
