using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierContador : MonoBehaviour
{
    [SerializeField] DeathComedor deaths;

    public int soldadoKo;
    SoldierLife soldierLife;
    void Start()
    {
        soldierLife = GetComponent<SoldierLife>();
    }

    // Update is called once per frame
    void Update()
    {
        ContadorDeaths();
    }
    void ContadorDeaths()
    {
        if(soldadoKo < 1 && soldierLife.vida <= 0)
        {
            soldadoKo++;
            deaths.enemyDeath++;
        }
    }
}
