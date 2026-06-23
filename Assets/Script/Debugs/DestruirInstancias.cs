using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DestruirInstancias : MonoBehaviour
{
    public bool destruirInstancia;

    public bool displayTutorial;
    public string idNivel;

    void Start()
    {

        /*
        for (int e = 0; e < variablesCoquetas.Count; e++)
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[e].modificacion)
            {
                variablesCoquetas[e].modificacion = true;
            }
        }*/

        //StatusGameobjectsVariables.statusGameobject.modificacion = new List<ListaModificaciones> variablesCoquetas;

    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Te has pasado el nivel " + idNivel);
        if (destruirInstancia)
        {
            if (DataPersistenceManager.instance.gameData.nivelesComplete.ContainsKey(idNivel))
            {
                DataPersistenceManager.instance.gameData.nivelesComplete.Remove(idNivel);
            }
            DataPersistenceManager.instance.gameData.nivelesComplete.Add(idNivel, displayTutorial);
            Debug.Log("Te has pasado el nivel " + idNivel);
            destruirInstancia = false;
        }
        //if(destruirInstancia)ObjectivesLevels.instanceObjectivesLevel.TaskObjectiveComplete(task);
        /*
        if (destruirInstancia) { Debug.Log("Has destruido la instancia de " + SaveScene.instancia.gameObject.name); Destroy(SaveScene.instancia.gameObject); destruirInstancia = false; }
        if(SaveScene.instancia == null)
        {
            Debug.Log("No existe instancia alguna de SaveScene");
        }
        else
        {
            Debug.Log("Existe una instancia, por tanto, puede destruirse");
        }
        */
    }
    public void ResetearVariablesGameObjects()
    {
        //No funciona dado que el hacer esto provocaria crear una copia exacta de  la lista, lo que hace que ambas se puedan actualizar constantemente.
        //StatusGameobjectsVariables.statusGameobject.modificacion = variablesCoquetas;
        Debug.Log("Reset Stats");
    }
}
