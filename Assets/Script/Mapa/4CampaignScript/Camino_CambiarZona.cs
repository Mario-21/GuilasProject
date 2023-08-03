using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camino_CambiarZona : MonoBehaviour
{

    [Header("Escena y Spawn")]
    public int siguienteEscena;
    public int checkpointSpanwScene;
    [Header("Icon")]
    [SerializeField] GameObject iconoZone;
    [SerializeField] SpriteRenderer iconeZoneSprite;
    [SerializeField] Sprite iconoArrow;
    [Header("Player")]
    [SerializeField]  GameObject playerCuerpo;
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;

    bool camino;
    BoxCollider2D triggerBox;
    private void Start()
    {
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
