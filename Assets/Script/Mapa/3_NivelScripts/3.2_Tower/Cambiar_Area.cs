using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ZonaChangeSound))]
public class Cambiar_Area: MonoBehaviour
{

    public int siguienteEscena;
    public int checkPoint;
    public bool usarCheckpoint;
    [Header("Orientacion Siguiente Nivel")]
    [Range(-1, 1)]
    public int orientacionNext;
    [Header("Tipo Cambio Area Escalera")]
    public bool escaleraSubir;
    public float gravedad;
    bool entrarCamino;


    //BloquearMovimientoPlayer bloqPlayer;
    ZonaChangeSound zonaChangeSound;

    private void Start()
    {
        zonaChangeSound = GetComponent<ZonaChangeSound>();
        //bloqPlayer = FindObjectOfType<BloquearMovimientoPlayer>();
    }
    private void Update()
    {
        if (entrarCamino) { CambiarNivel(); }
    }
    void CambiarNivel()
    {
        ListDataPlayer.listDataPlayer.orientacionPlayer = orientacionNext;
        zonaChangeSound.CambiarZonaSound();
        //bloqPlayer.BloquearMovPlayer();
        BloquearMovimientoPlayer.instanceBloqPlayerMov.BloquearMovPlayer();
        EstructuraNiveles.nivel = siguienteEscena;
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
        if (usarCheckpoint) CheckPointController.numeroCheckPoint = checkPoint;
    }
    void TipoCambioAreaEscalera()
    {
        if (!escaleraSubir)
        {
            BloquearMovimientoPlayer.instanceBloqPlayerMov.playerRB.gravityScale = gravedad;
        }
        else
        {
            BloquearMovimientoPlayer.instanceBloqPlayerMov.playerRB.gravityScale = -gravedad;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //ListDataPlayer.listDataPlayer.orientacionPlayer = (int)bloqPlayer.player.transform.localScale.x;
            entrarCamino = true;
        }
    }
}
