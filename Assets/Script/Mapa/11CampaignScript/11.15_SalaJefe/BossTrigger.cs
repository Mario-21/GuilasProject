using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public int indexMod;

    [Header("Time Scene Boss")]
    public float waitBossLimit;
    public float waitBoss;
    [Header("Scena Boss")]
    public int scenaBoss;
    public int spawnBoss;
    [Header("Ascensor")]
    [SerializeField] Camino_CambiarZona ascensor;

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
                ascensor.enabled = false;
                CheckPointController.numeroCheckPoint = spawnBoss;
                EstructuraNiveles.nivel = scenaBoss;
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
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
