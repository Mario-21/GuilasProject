using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpEnfermeria : MonoBehaviour
{
    [Header("Soldados Ayuda Veneno")]
    [SerializeField] GameObject soldado1;
    [SerializeField] GameObject spawnSoldado1;
    [SerializeField] GameObject soldado2;
    [SerializeField] GameObject spawnSoldado2;
    void Start()
    {
        if (ExtraVariable.extras.helpSoldados)
        {
            soldado1.SetActive(true);
            spawnSoldado1.SetActive(true);
            soldado2.SetActive(true);
            spawnSoldado2.SetActive(true);
        }
    }


}
