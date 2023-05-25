using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel1 : MonoBehaviour
{
    public GameObject completarNivel;
    [Header("Terminales Conditions")]
    [SerializeField] TotalTerminales terminales;
    public int numeroTotalesTerminal;
    [Header("Vehiculo Conditions")]
    public int indexVehiculo;

    // Update is called once per frame
    void Update()
    {
        RuleLevel();
    }
    void RuleLevel()
    {
        if(terminales.terminalesActivados >= numeroTotalesTerminal && StatusGameobjectsVariables.statusGameobject.modificacion[indexVehiculo].modificacion)
        {
            completarNivel.SetActive(true);
        }
    }
}
