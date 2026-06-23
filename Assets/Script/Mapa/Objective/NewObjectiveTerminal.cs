using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectiveTerminal : MonoBehaviour
{
    //ESte script es el antiguo, el obsoleto de los portatiles terminales.


    public int indexMod;

    Portatil_Info terminal;
    [Header("What's Task")]
    public int taskWho;
    private void Awake()
    {
        terminal = GetComponent<Portatil_Info>();
    }
    void Start()
    {
        //Al completar la Task, desactiva el script
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);//TaskWhoIAmTerminal();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TotalTerminales.terminalesTotales.terminalesActivos[terminal.indexTerminal])
        {
            if (TotalTerminales.terminalesTotales.carga)
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            }
        }
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);//TaskWhoIAmTerminal();
        }
    }
    public void TaskWhoIAmTerminal()
    {
        if (ObjectivesLevels.instanceObjectivesLevel.indexLine == taskWho)
        {
            ObjectivesLevels.instanceObjectivesLevel.indexLine++;
            this.enabled = false;
        }
        else if (ObjectivesLevels.instanceObjectivesLevel.indexLine > taskWho)
        {
            this.enabled = false;
        }
    }
}
