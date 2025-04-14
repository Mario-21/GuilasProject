using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FMODUnity;

public class Desembarcar : MonoBehaviour
{
    [Header("Time Desembarcar")]
    public float timeDesembarcarLimit;
    float timeDesembarcar;
    [Header("Player Data")]
    [SerializeField] BloquearMovimientoPlayer habPlayer;
    [SerializeField] GameObject player;
    [SerializeField] Transform playerSpawnDesembarco;
    [SerializeField] Rigidbody2D playerRb2d;
    [SerializeField] TriggerFollowSoldier followBarcaPlayer;
    [SerializeField] JugadorMovimiento movimientoPlayer;
    [SerializeField] Stairs_Hidden stairsPlayer;
    [Header("Barco Data")]
    [SerializeField] GameObject barca;
    [SerializeField] SaveButton barcaButton;
    [SerializeField] Barco barcoScript;
    [Header("Water Data")]
    [SerializeField] DamageWaterPosion waterPoison;
    [Header("Camera Data")]
    [SerializeField] CinemachineVirtualCamera mainCamera;
    [Header("Icono desembarcar")]
    [SerializeField] GameObject iconoZone;
    [SerializeField] SpriteRenderer iconeZoneSprite;
    [SerializeField] Sprite iconoDesembar;
    [Header("Desembarcar SFX")]
    [SerializeField] EventReference sfx_Desembarcar;

    bool barcoOrilla;
    bool desembarcar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (barcoOrilla)
        {
            iconeZoneSprite.sprite = iconoDesembar;
            iconoZone.SetActive(true);
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(sfx_Desembarcar);
                desembarcar = true;
            }
        }
        if (desembarcar) Desembarco();
    }
    void Desembarco()
    {
        if(timeDesembarcar >= timeDesembarcarLimit)
        {
            //Player cambios caracteristicas
            playerRb2d.bodyType = RigidbodyType2D.Dynamic; 
            followBarcaPlayer.enabled = false; //ya no sigo a la barca
            movimientoPlayer.enabled = true; //puedo volver a moverme
            stairsPlayer.enabled = true; //puedes volver a usar escaleras
            //Player se coloca en el spawn
            player.transform.position = playerSpawnDesembarco.position;
            //Barca desaparece
            barca.SetActive(false);
            //Habilitas el daño por agua
            waterPoison.enabled = true;
            //Habilitar boton
            barcaButton.HabilitarUsos();
            //Camera Player
            mainCamera.Follow = player.transform;
            //Guarda la pala
            //Llamar Transicion
            AnimationHud.detectar_echar.SetBool("Transicion", false);
            //Desactivas el desembarcar
            desembarcar = false;
            //Resetea el TimeDesembarcar para poder volver a usarlo
            timeDesembarcar = 0;
            //Habilitar Movimiento
            habPlayer.HabilitarMovPlayer();
            //Habilitar Barco
            barcoScript.enabled = true;
            //Fuera Icono
            iconoZone.SetActive(false);
            
        }
        else
        {
            AnimationHud.detectar_echar.SetBool("Transicion", true);
            barcoScript.enabled = false;
            timeDesembarcar += Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barco"))
        {
            barcoOrilla = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barco"))
        {
            Debug.Log("Barca en la orilla");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barco"))
        {
            barcoOrilla = false;
            iconoZone.SetActive(false);
        }
    }
}
