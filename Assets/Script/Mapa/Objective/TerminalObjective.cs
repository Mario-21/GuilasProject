using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalObjective : MonoBehaviour
{
    public int indexMod;
    [Header("What's Task")]
    public int taskWho;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TotalTerminales.terminalesTotales.carga)
        {
            TaskWhoIAmTerminal();
        }
    }
    void TaskWhoIAmTerminal()
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
