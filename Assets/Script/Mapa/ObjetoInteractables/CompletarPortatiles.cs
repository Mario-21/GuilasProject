using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletarPortatiles : MonoBehaviour
{
    public GameObject completarNivel;

    public List<int> terminalesIndex;

    public int numTotalTerminales;
    public int numActualTerminales;

    void Start()
    {
        ComprobarTerminales();
    }
    void Update()
    {
        CompletarTerminales();
    }
    void CompletarTerminales()
    {
        if(numActualTerminales >= numTotalTerminales)
        {
            completarNivel.SetActive(true);
        }
    }
    public void ComprobarTerminales()
    {
        for (int e = 0; e < terminalesIndex.Count; e++)
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[terminalesIndex[e]].modificacion)
            {
                Debug.Log("Terminal Index Removido" + terminalesIndex[e]);
                numActualTerminales++;
                //Esto se hace para cuando lo ejecutes en el update, no te vuelva a contar uno que ya tengas 
                //has obtenido.
                terminalesIndex.Remove(terminalesIndex[e]);
               
            }
        }
    }
}
