using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListaStatusSoldierScenes
{
    // Start is called before the first frame update
    public string SoldierName;
    public int statusVida;
    public bool berserkerStatus;
    [HideInInspector]public bool warningSoldier;
    [HideInInspector]public float position_x; //x
    [HideInInspector]public float position_y; //y
    public int deathScene;
    public bool imDead;
    [HideInInspector] public int scaleEnemy;
}
