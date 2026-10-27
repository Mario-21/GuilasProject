using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledCinematicCave : MonoBehaviour
{
    public bool verCave;
    [Header("Conditions CinematicCave")]
    public int indexActiveCinCave;
    [SerializeField] SoldadoNormal scientific_1;
    [SerializeField] SoldierLife scientific_1Life;
    [SerializeField] SoldadoNormal scientific_2;
    [SerializeField] SoldierLife scientific_2Life;
    [Header("Finish Cave")]
    public int indexFinishCave;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexFinishCave].modificacion) this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Si uno esta  vivo 
        if(scientific_1Life.vida > 0  && scientific_2Life.vida > 0 && !scientific_1.berserker && !scientific_2.berserker ||
            scientific_1Life.vida <= 0 && scientific_2Life.vida > 0 && !scientific_2.berserker ||
            scientific_1Life.vida > 0 && !scientific_1.berserker && scientific_2Life.vida <= 0) 
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexActiveCinCave].modificacion = true;
            verCave = true;
        }
        else if(scientific_1Life.vida <= 0 && scientific_2Life.vida <= 0 ||
            scientific_1.berserker || scientific_2.berserker)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexActiveCinCave].modificacion = false;
            verCave = false;
        }
    }
}
