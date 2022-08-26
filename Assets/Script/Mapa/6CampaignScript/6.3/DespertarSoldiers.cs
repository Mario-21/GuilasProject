using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespertarSoldiers : MonoBehaviour
{
    [SerializeField] KillAllEnemy conditions;
    PlayerHere player;

    private void Start()
    {
        player = GetComponent<PlayerHere>();
    }
    void Update()
    {
       if(player.playerImHere)WakeUpSoldiers();
    }
    void WakeUpSoldiers()
    {
        if(conditions.numSoldiers > 0)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log("Gol");
                for (int i = 0; i < conditions.soldiersDeath.Count; i++)
                {
                    conditions.soldiersDeath[i].GetComponent<SoldierLife>().vida = 1;
                }
            }
        }
    }
}
