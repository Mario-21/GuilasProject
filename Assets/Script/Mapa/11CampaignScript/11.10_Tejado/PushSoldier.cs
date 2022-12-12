using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSoldier : MonoBehaviour
{
    public int indexMod;
    [Header("Soldado Info")]
    [SerializeField] SoldierLife soldadoVida;
    bool soldadoInside;
    [Header("Player Data")]
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;
    [SerializeField] GameObject cuerpoPlayer;
    PlayerHere player;
    [Header("Time Push")]
    [SerializeField] float timePushLimit;
    float timePush;
    bool push;
    BoxCollider2D colliderTrigger;
    void Start()
    {
        colliderTrigger = GetComponent<BoxCollider2D>();
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PushEnemy();
        Push();
    }
    void PushEnemy()
    {
        if (player.playerImHere)
        {
            if(soldadoVida.vida > 0 && soldadoInside)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    //Recarga la escena emitiendo un sonido

                    //Bloquear movimiento y transicion
                    AnimationHud.detectar_echar.SetBool("Transicion", true);
                    bloqPlayer.BloquearMovPlayer();
                    cuerpoPlayer.layer = 0;
                    //Le has empujado
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                    push = true;
                    //Desactivar collider para no spamear el boton y poder ejecutar esta accion todo el rato
                    colliderTrigger.enabled = false;
                }
            }
        }
    }
    void Push()
    {
        if (push)
        {
            timePush += Time.deltaTime;
            if(timePush >= timePushLimit)
            {
                //La pantalla vuelve a la normalidad
                AnimationHud.detectar_echar.SetBool("Transicion", false);
                //Puedes Moverte
                bloqPlayer.HabilitarMovPlayer();
                //Soldado Fake
                cuerpoPlayer.layer = 16;
                //El soldado se << va >> y deshabilitas este objeto
                soldadoVida.gameObject.SetActive(false);
                this.gameObject.SetActive(false);

                push = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            soldadoInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            soldadoInside = false;
        }
    }
}
