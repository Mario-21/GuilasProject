using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWetCinematic : MonoBehaviour
{
    [Header("Soldados Data")]
    [SerializeField] SoldadoNormal soldierSwitch;
    [SerializeField] SoldierLife soldierSwitchLife;
    [SerializeField] SoldadoNormal soldierNormal;
    [SerializeField] SoldierLife soldierNormalLife;
    [Header("Soldados Distance")]
    [SerializeField] Vector2 distanceSoldiers;
    [Header("Trigger Cinematica")]
    [SerializeField] GameObject triggerCinematico;

    int once;
    void Update()
    {
        distanceSoldiers = DistanceBetweenSoldiers();

        if(soldierSwitchLife.vida <= 0 && !soldierNormal.berserker)
        {
            if (once < 1)
            {
                triggerCinematico.transform.position = new Vector2(soldierNormal.transform.position.x + DistanceBetweenSoldiers().x, soldierNormal.transform.position.y);
                once++;
            }
        }
        if (soldierNormal.berserker)
        {
            triggerCinematico.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    Vector2 DistanceBetweenSoldiers()
    {
        Vector2 distance;
        return distance = new Vector2 ((soldierSwitch.transform.position.x - soldierNormal.transform.position.x)/2, soldierSwitch.transform.position.y - soldierNormal.transform.position.y);
    }
}
