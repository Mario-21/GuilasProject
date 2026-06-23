using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalObjective : MonoBehaviour
{
    [Header("What's Task")]
    public int taskWho;
    [Header("Completar_Portatiles")]
    [SerializeField] CompletarPortatiles completarPortatiles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (completarPortatiles.numActualTerminales >= completarPortatiles.numTotalTerminales)
        {
            //TaskWhoIAmTerminal();
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);
            this.enabled = false;
        }
    }
}
