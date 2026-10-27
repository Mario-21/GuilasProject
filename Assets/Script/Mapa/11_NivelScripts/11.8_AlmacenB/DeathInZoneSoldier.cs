using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathInZoneSoldier : MonoBehaviour
{
    //Cuando un soldado muere en una zona en concreto una variable se Activara
    public int indexMod;

    [SerializeField] SoldierLife soldadoVida;

    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion || soldadoVida.vida <= 0)
        {
            this.enabled = false;
            Debug.Log("Gon Muere Start");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(soldadoVida.vida <= 0)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            Debug.Log("Gon Muere Update");
        }
    }
}
