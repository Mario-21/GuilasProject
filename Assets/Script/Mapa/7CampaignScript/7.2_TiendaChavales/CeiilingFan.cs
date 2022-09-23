using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeiilingFan : MonoBehaviour
{
    public int indexMod;
    [Header("Velocidad")]
    public float speed;
    public  bool onCeilingFan;
    [Header("On Ceiling Fan")]
    [SerializeField] Transform ceilingFan;
    [Header("Soldier Switch")]
    [SerializeField] SoldierLife soldierSwitchLife;
    bool enemyHere;
    float timeOnCeiling;
    public float timeOnCeilingLimit = 1.5f;

    PlayerHere player;
    void Start()
    {
        player = GetComponent<PlayerHere>();
    }
    void Update()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ActiveCeilingFan();
            CeilingFan();
            SoldierOnCeiling();
        }
    }
    void ActiveCeilingFan()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                onCeilingFan = !onCeilingFan;
            }
        }
        
    }
    void CeilingFan()
    {
        if (onCeilingFan)
        {
            ceilingFan.Rotate(0f, speed, 0f);
        }
        else
        {
            ceilingFan.Rotate(0f, 0f, 0f);
        }
    }
    void SoldierOnCeiling()
    {
        //On Ceiling Pan
        if (enemyHere && soldierSwitchLife.vida > 0)
        {
            timeOnCeiling += Time.deltaTime;
            if (timeOnCeiling >= timeOnCeilingLimit)
            {
                onCeilingFan = true;
                timeOnCeiling = 0;
                enemyHere = false;
            }
        }
        else
        {
            timeOnCeiling = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) enemyHere = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            enemyHere = false;
            timeOnCeiling = 0;
        }
    }
}
