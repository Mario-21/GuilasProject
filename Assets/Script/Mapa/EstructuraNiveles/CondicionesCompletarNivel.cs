using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionesCompletarNivel : MonoBehaviour
{
    int numCondCumplidasActual;
    public int numCondCumplidasTotal;

    public GameObject recompensa;

    public List<int> condicionesIndex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numCondCumplidasActual < numCondCumplidasTotal)
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[condicionesIndex[0]].modificacion)
            {
                condicionesIndex.RemoveAt(0);
                numCondCumplidasActual++;
                //terminalesIndex.Remove(terminalesIndex[indexVerdadero]);
            }
        }
        else if(numCondCumplidasActual >= numCondCumplidasTotal)
        {
            recompensa.SetActive(true);
        }
    }
}
