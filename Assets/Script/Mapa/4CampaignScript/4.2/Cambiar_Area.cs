using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ZonaChangeSound))]
public class Cambiar_Area: MonoBehaviour
{

    public int siguienteEscena;
    public int checkPoint;
    public bool usarCheckpoint;
    bool entrarCamino;

    BloquearMovimientoPlayer bloqPlayer;
    ZonaChangeSound zonaChangeSound;

    private void Start()
    {
        zonaChangeSound = GetComponent<ZonaChangeSound>();
        bloqPlayer = FindObjectOfType<BloquearMovimientoPlayer>();
    }
    private void Update()
    {
        if (entrarCamino) { CambiarNivel(); }
    }
    void CambiarNivel()
    {
        zonaChangeSound.CambiarZonaSound();
        bloqPlayer.BloquearMovPlayer();
        EstructuraNiveles.nivel = siguienteEscena;
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
        if (usarCheckpoint) CheckPointController.numeroCheckPoint = checkPoint;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            entrarCamino = true;
        }
    }
}
