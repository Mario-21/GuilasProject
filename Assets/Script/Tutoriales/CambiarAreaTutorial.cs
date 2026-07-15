using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarAreaTutorial : MonoBehaviour
{
    [Header("Definir Tutorial Carga")]
    public string definirTutorial;
    [Header("Datos Siguiente Escena")]
    public int siguienteEscena;
    public int checkPoint;
    public bool usarCheckpoint;
    [Header("Orientacion Siguiente Nivel")]
    [Range(-1, 1)]
    public int orientacionNext;

    bool entrarCamino;

    ZonaChangeSound zonaChangeSound;
    void Start()
    {
        zonaChangeSound = GetComponent<ZonaChangeSound>();
    }

    // Update is called once per frame
    void Update()
    {
        if (entrarCamino) { CambiarNivelATutorial(); }
    }
    void CambiarNivelATutorial()
    {
        ListDataPlayer.listDataPlayer.orientacionPlayer = orientacionNext;
        zonaChangeSound.CambiarZonaSound();
        //bloqPlayer.BloquearMovPlayer();
        BloquearMovimientoPlayer.instanceBloqPlayerMov.BloquearMovPlayer();
        EstructuraNiveles.nivel = siguienteEscena;
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
        if (usarCheckpoint) CheckPointController.numeroCheckPoint = checkPoint;

        //Define qur pantalla de carga aparecera en la siguiente escena.
        ControladorListasNivel.nombreSiguienteNivel = definirTutorial;
        //Desactivar el controlerTutoriales en caso de que haya una queue contenida
        if (ControlerTutoriales.instanciaTutoriales.colaTutoriales.Count > 0) ControlerTutoriales.instanciaTutoriales.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            entrarCamino = true;
        }
    }
}
