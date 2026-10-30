using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ZonaChangeSound))]
public class CaminoCambiarZonaTutorial : MonoBehaviour
{
    [Header("Definir Tutorial Carga")]
    public string definirTutorial;
    [Header("Escena y Spawn")]
    public int siguienteEscena;
    public string nombreSiguienteEscena;
    public int checkpointSpanwScene;
    [Header("Icon")]
    [SerializeField] GameObject iconoZone;
    [SerializeField] SpriteRenderer iconeZoneSprite;
    [SerializeField] Sprite iconoArrow;
    [Header("Player")]
    [SerializeField] GameObject playerCuerpo;

    bool camino;
    BoxCollider2D triggerBox;
    ZonaChangeSound zonaChange;

    private void Start()
    {
        zonaChange = GetComponent<ZonaChangeSound>();
        triggerBox = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        Caminar();

    }
    // Update is called once per frame
    public void Caminar()
    {
        if (camino)
        {
            iconeZoneSprite.sprite = iconoArrow;
            iconoZone.SetActive(true);
            if (Input.GetButtonDown("Action"))
            {
                ListDataPlayer.listDataPlayer.orientacionPlayer = (int)BloquearMovimientoPlayer.instanceBloqPlayerMov.player.transform.localScale.x;
                zonaChange.CambiarZonaSound();
                //Desactivar collider
                triggerBox.enabled = false;
                iconoZone.SetActive(false);
                //Para que no que los enemigos si te ven, no te ataquen al cambiar de zona
                playerCuerpo.layer = 0;
                //Parar el Movimiento del Player
                BloquearMovimientoPlayer.instanceBloqPlayerMov.BloquearMovPlayer();
                //Cambiar Zona
                CheckPointController.numeroCheckPoint = checkpointSpanwScene;
                EstructuraNiveles.nivel = siguienteEscena;
                EstructuraNiveles.nombreNivel = nombreSiguienteEscena;
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                iconoZone.SetActive(false);
                //Define qur pantalla de carga aparecera en la siguiente escena.
                ControladorListasNivel.nombreSiguienteNivel = definirTutorial;
                //Desactivar el controlerTutoriales en caso de que haya una queue contenida
                if (ControlerTutoriales.instanciaTutoriales.colaTutoriales.Count > 0) ControlerTutoriales.instanciaTutoriales.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camino = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camino = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camino = false;
            iconoZone.SetActive(false);
        }
    }
}
