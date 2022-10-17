using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentilationGrill : MonoBehaviour
{
    public int indexMod;
    ActivarModificador activar;
    public GameObject ventilation;

    void Start()
    {
        activar = GetComponent<ActivarModificador>();

        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            RemoveVentilationGrille();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(activar.modificacion) RemoveVentilationGrille();
    }
    void RemoveVentilationGrille()
    {
        ventilation.SetActive(false);
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        //Se desactiva para que no puedas a volver a realizar la acción y no te quite uses a los objetos si tienen más de un uso
        this.enabled = false;
    }
}
