using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenenoCin : MonoBehaviour
{
    public int indexMod;
    ActivarModificador activador;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activador.modificacion)
        {
            ExtraVariable.extras.comedorScene = ExtraVariable.CinematicComedor105.Veneno;
        }
        
    }
    
}
