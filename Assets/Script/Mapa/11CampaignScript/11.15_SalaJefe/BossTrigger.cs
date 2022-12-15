using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public int indexMod;

    [Header("Time Scene Boss")]
    public float waitBossLimit;
    float waitBoss;
    [Header("Scena Boss")]
    public int scenaBoss;
    public int spawnBoss; 

    bool bossWait;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BossAppear();
    }
    void BossAppear()
    {
        if (bossWait)
        {
            waitBoss += Time.deltaTime;
            if(waitBoss >= waitBossLimit)
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                CheckPointController.numeroCheckPoint = spawnBoss;
                EstructuraNiveles.nivel = scenaBoss;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bossWait = true;
        }
    }
}
