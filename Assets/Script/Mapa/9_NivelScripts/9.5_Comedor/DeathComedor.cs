using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComedor : MonoBehaviour
{
    public int indexModVenenoGlass; // Equivale al 5
    public int indexComedorDeath; //Variable nueva
    [Header("Total Enemigos")]
    public int totalEnemy;
    public int enemyDeath;
    [SerializeField] Aparecer_DesAp_Obj soldadosAspersores;

    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexComedorDeath].modificacion)
        {
            soldadosAspersores.enabled = false;
            this.enabled = false;
        }
        
    }
    private void Update()
    {
        CantidadEnemigos();
        //Aplicar lo mismo pero solo a los dos soldados del baño
        if (enemyDeath >= totalEnemy)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexComedorDeath].modificacion = true;
            soldadosAspersores.enabled = false;
        }
    }
    void CantidadEnemigos()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModVenenoGlass].modificacion)
        {
            totalEnemy = 5;
        }
        else
        {
            totalEnemy = 7;
        }
    }
}
