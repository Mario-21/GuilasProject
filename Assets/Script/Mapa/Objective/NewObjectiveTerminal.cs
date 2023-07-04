using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectiveTerminal : MonoBehaviour
{
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
            TaskWhoIAmTerminal();
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
            TaskWhoIAmTerminal();
        }
    }
    public void TaskWhoIAmTerminal()
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
