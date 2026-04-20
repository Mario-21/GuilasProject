using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPruebas : MonoBehaviour
{
    public float numero_A;
    public float numero_B;

    public float numeroLimite;
    public float numeroTotal;

    public bool dosdieces;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReturnCosas1();
        DebugeoPostReturn();
    }
    void ReturnCosas1()
    {
        if(numero_A + numero_B < numeroTotal)
        {
            dosdieces = true;
            Debug.Log("El bool dosdieces se ha activado " + dosdieces);
            return;
        }
        Debug.Log("Return no ejecutado");
        //DebugeoPostReturn();
    }
    void DebugeoPostReturn()
    {
        if(numero_A > numero_B)
        {
            Debug.Log("Numero A" + numero_A + " es mayor que Numero B " + numero_B);
        }
    }

    public float DistanceCabezaPlayerEnemy()
    {
        float distanciaCabezas;
        return distanciaCabezas = numero_A - numero_B;
    }
}
