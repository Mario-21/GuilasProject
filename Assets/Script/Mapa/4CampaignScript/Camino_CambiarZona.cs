using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ZonaChangeSound))]
public class Camino_CambiarZona : MonoBehaviour
{
    [Header("Estado de la puerta")]
    [SerializeField] bool locker;
    ScientificRoomOpen lockDoor;
    [Header("Escena y Spawn")]
    public int siguienteEscena;
    public int checkpointSpanwScene;
    [Header("Icon")]
    [SerializeField] GameObject iconoZone;
    [SerializeField] SpriteRenderer iconeZoneSprite;
    [SerializeField] Sprite iconoArrow;
    [Header("Player")]
    [SerializeField] GameObject playerCuerpo;
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;


    bool camino;
    BoxCollider2D triggerBox;
    ZonaChangeSound zonaChange;
    private void Start()
    {
        zonaChange = GetComponent<ZonaChangeSound>();
        triggerBox = GetComponent<BoxCollider2D>();
        if (locker) lockDoor = GetComponent<ScientificRoomOpen>();
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
                zonaChange.CambiarZonaSound();
                //Desactivar collider
                triggerBox.enabled = false;
                iconoZone.SetActive(false);
                //Para que no que los enemigos si te ven, no te ataquen al cambiar de zona
                playerCuerpo.layer = 0;
                //Parar el Movimiento del Player
                bloqPlayer.BloquearMovPlayer();
                //Cambiar Zona
                CheckPointController.numeroCheckPoint = checkpointSpanwScene;
                EstructuraNiveles.nivel = siguienteEscena;
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                iconoZone.SetActive(false);
                if (locker) lockDoor.OpenScientificRoom();
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
