using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectar_Echar_Deep : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] Inventory inventoryPlayer;
    [SerializeField] JugadorMovimiento movPlayer;
    [SerializeField] BloquearMovimientoPlayer player;
    [Header("Enemy Data")]
    [SerializeField] SoldadoProfundo soldadoDeep;
    [SerializeField] SoldierDeepLife soldadoDeepLife;
    [Header("Scene")]
    public int sceneReload;
    public string nombreSiguienteEscenaRecargar;
    public int spawn;

    bool evento;
    bool balaInside;

    ObjetoInteractivo objInter;

    float timeDialogo;
    int reactivateInventory;
    enum SecuenceDetect
    {
        girarSoldado,
        showDialogo,
        resetScene

    }
    SecuenceDetect detectScene;
    private void Awake()
    {
        movPlayer = FindObjectOfType<JugadorMovimiento>();
        objInter = GetComponent<ObjetoInteractivo>();
    }
    private void Update()
    {
        if(soldadoDeepLife.vida > 0 && evento && !balaInside)
        {
            Secuence();
        }
        if(soldadoDeepLife.vida <= 0)
        {
            if (reactivateInventory < 1)
            {
                inventoryPlayer.enabled = true;
                reactivateInventory++;
            }
            Destroy(this);
            player.HabilitarMovPlayer();
        }
    }
    public void Secuence()
    {
        switch (detectScene)
        {
            case SecuenceDetect.girarSoldado:
                inventoryPlayer.enabled = false;
                inventoryPlayer.inventory.SetActive(false);
                //Apaga al soldado
                soldadoDeep.enabled = false;
                EstructuraNiveles.nivel = sceneReload;
                EstructuraNiveles.nombreNivel = nombreSiguienteEscenaRecargar;
                if (!balaInside) detectScene = SecuenceDetect.showDialogo;
                break;
            case SecuenceDetect.showDialogo:
                timeDialogo += Time.deltaTime;
                if (timeDialogo >= 1) objInter.DetenerDialogo();
                if (timeDialogo >= 2) detectScene = SecuenceDetect.resetScene;
                break;
            case SecuenceDetect.resetScene:
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                CheckPointController.numeroCheckPoint = spawn;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer")) balaInside = true;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (movPlayer.onGround && collision.gameObject.CompareTag("Player"))
        {
            evento = true;
            if (!balaInside && !ArmaController.preCollisionObject) player.BloquearMovPlayer();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer")) balaInside = false;
    }
}
