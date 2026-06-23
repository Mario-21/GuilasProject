using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNewObjective : MonoBehaviour
{
    public int indexMod;

    [Header("What's Task")]
    public int taskWho;
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);//TaskWhoIAmTrigger();
            this.enabled = false;
        }
    }
    private void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);//TaskWhoIAmTrigger();
            this.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Colocar la variable para que no me vaya incrementando constantemente el index
            if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
            {
                //Salta la animacion de la nueva nota.
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            }
        }
    }
}
