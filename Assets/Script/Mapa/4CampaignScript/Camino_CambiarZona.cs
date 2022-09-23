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

    bool camino;

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
            if (Input.GetKeyDown(KeyCode.Z))
            {
                CheckPointController.numeroCheckPoint = checkpointSpanwScene;
                EstructuraNiveles.nivel = siguienteEscena;
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                iconoZone.SetActive(false);
            }
        }
        else
        {
            iconoZone.SetActive(false);
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
        } 
    }
}
