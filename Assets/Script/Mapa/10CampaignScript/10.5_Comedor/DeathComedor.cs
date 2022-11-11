using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComedor : MonoBehaviour
{
    [Header("Total Enemigos")]
    public int totalEnemy;
    public int enemyDeath;
    [SerializeField] Aparecer_DesAp_Obj soldadosAspersores;
    [SerializeField] HelpDeath helpDeath;

    private void Start()
    {
        if (ExtraVariable.extras.soldadosDeathComedor)
        {
            soldadosAspersores.enabled = false;
            this.enabled = false;
        }
        if (ExtraVariable.extras.helpSoldados)
        {
            totalEnemy = 5;
        }
        else
        {
            totalEnemy = 7;
        }
    }
    private void Update()
    {
        //Aplicar lo mismo pero solo a los dos soldados del baño
        if (enemyDeath >= totalEnemy)
        {
            ExtraVariable.extras.soldadosDeathComedor = true;
            soldadosAspersores.enabled = false;
        }
    }
}
