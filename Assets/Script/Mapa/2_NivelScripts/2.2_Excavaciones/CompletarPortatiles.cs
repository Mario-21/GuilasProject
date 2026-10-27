using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletarPortatiles : MonoBehaviour
{
    public GameObject completarNivel;

    public List<int> terminalesIndex;

    public int numTotalTerminales;
    public int numActualTerminales;

    int indexVerdadero;
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
        
        for (int e = 0; indexVerdadero < terminalesIndex.Count; e++)
        {

            if (StatusGameobjectsVariables.statusGameobject.modificacion[terminalesIndex[indexVerdadero]].modificacion)
            {
                Debug.Log("Terminal Index Removido" + terminalesIndex[indexVerdadero]);
                numActualTerminales++;
                //Esto se hace para cuando lo ejecutes en el update, no te vuelva a contar uno que ya tengas 
                //has obtenido.
                terminalesIndex.Remove(terminalesIndex[indexVerdadero]);
               
            }
            else
            {
                indexVerdadero++;
            }
        }
        /*
        //CUidado le pasaria lo mismo que en el for si antes no eliminas el index de la lista
        foreach(int indexTerm in terminalesIndex)
        {
            Debug.Log("Cuantos terminales estan en la lista" + indexTerm);
            if (StatusGameobjectsVariables.statusGameobject.modificacion[indexTerm].modificacion)
            {
                Debug.Log("Se ha completado el terminal" + indexTerm);
                terminalesIndex.Remove(terminalesIndex[indexTerm]);
            }


        }*/
    }
    public void ResetearIndex()
    {
        indexVerdadero = 0;
    }
}
