using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectar_y_Echar_Cameras : MonoBehaviour
{
    [Header("Menu Player")]
    [SerializeField] Inventory menuPlayer;
    [Header("Player Data")]
    [SerializeField] GameObject cuerpoPlayer;
    JugadorMovimiento movPlayer;
    [SerializeField] BloquearMovimientoPlayer player;
    [Header("Scene")]
    public int sceneReload;
    public string nombreEscenaRecarga;
    public int spawn;

    bool evento;

    enum SecuenceDetect
    {
        girarSoldado,
        showDialogo,
        resetScene

    }
    SecuenceDetect detectScene;


    float timeDialogo;
    private void Awake()
    {
        movPlayer = FindObjectOfType<JugadorMovimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        //Change the script: SoldadoDet/Echar out, now you have the same script in all soldier, but with
        //the difference that soldier with trigger will have low range
        //Hacer script aditional con la rama nivel 2 si el estatus es true destruye esto
        if (evento)
        {
            player.BloquearMovPlayer();
            Secuence();
        }

    }
    public void Secuence()
    {
        switch (detectScene)
        {
            case SecuenceDetect.girarSoldado:
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.securityCamAlert);
                //Inhabilita mi inventario
                menuPlayer.enabled = false;
                menuPlayer.inventory.SetActive(false);
                //Colocar Nivel
                EstructuraNiveles.nivel = sceneReload;
                EstructuraNiveles.nombreNivel = nombreEscenaRecarga;
                detectScene = SecuenceDetect.showDialogo;
                break;
            case SecuenceDetect.showDialogo:
                timeDialogo += Time.deltaTime;
                if (timeDialogo >= 1.5) detectScene = SecuenceDetect.resetScene;
                break;
            case SecuenceDetect.resetScene:
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                CheckPointController.numeroCheckPoint = spawn;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            evento = true;
            cuerpoPlayer.layer = 0;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (movPlayer.onGround && collision.gameObject.CompareTag("Player"))
        {
            evento = true;
        }
    }
}
