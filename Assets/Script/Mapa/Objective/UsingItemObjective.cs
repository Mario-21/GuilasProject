using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingItemObjective : MonoBehaviour
{

    public int indexMod;

    ActivarModificador activador;

    [Header("What's Task")]
    public int taskWho;

    private void Awake()
    {
        activador = GetComponent<ActivarModificador>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            //TaskWhoIAm() solo funcionara cuando el numero se ha igual, por tanto, en cuanto sea superior no lo desactivara
            //para eso existe esta condicion
            //TaskWhoIAmItem();
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activador.modificacion)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            //Esto se hace por si dos Task coinciden en la misma escena, de esta manera no inhabilitara el script hasta que llegue su Task
            //TaskWhoIAmItem();
            ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(taskWho);
            this.enabled = false;
        }
    }
}
