using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSpawn : MonoBehaviour
{
    [SerializeField] CheckPointController checkPointController;
    [SerializeField] RegretScene regret;
    void Start()
    {
        for(int e = 0; e < checkPointController.checkpoints.Length; e++)
        {
            //Compara el checkpoint; como esta cinematica sale primero antes que la escena jugable se hace para que sepa por el lado en el que entraste y no cambie de spawn.
            if(e == CheckPointController.numeroCheckPoint)
            {
                //Una vez sabe por el lado en el que entraste, rompe la ejecucion
                regret.spawn = e;
                break;
            }
        }
    }
}
