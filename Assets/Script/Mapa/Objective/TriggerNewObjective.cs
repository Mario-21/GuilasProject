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
            TaskWhoIAmTrigger();
        }
    }
    private void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            TaskWhoIAmTrigger();
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
    public void TaskWhoIAmTrigger()
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
