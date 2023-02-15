using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Embarcar : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D playerRb2d;
    [SerializeField] TriggerFollowSoldier followBarcaPlayer;
    [SerializeField] JugadorMovimiento movimientoPlayer;
    [SerializeField] Stairs_Hidden stairsPlayer;
    [Header("Water Data")]
    [SerializeField] WaterData waterInfo;
    [SerializeField] DamageWaterPosion waterPoison;
    [Header("Barco Data")]
    public string tagName;
    [SerializeField] GameObject barca;
    [SerializeField] Transform barcaSpawn;
    [SerializeField] SaveButton buttonBarco;
    [SerializeField] int horientacionBarco;
    [Header("Time Embarcar")]
    public float timeEmbarcarLimit;
    float timeEmbarcar;
    [Header("Camera Data")]
    [SerializeField] CinemachineVirtualCamera mainCamera;

    bool useBarco;
    bool playerRange;
    bool putBarco;
    BoxCollider2D colliderEmbarcar;

    private void Awake()
    {
        colliderEmbarcar = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        EmbarcarTrigger();

        if (useBarco && playerRange && bloqPlayer.player.onGround)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                putBarco = true;
            }
        }
        //Si Activas el barco, se va a ir colocando
        if (putBarco) ColocarBarco();
    }
    void ColocarBarco()
    {
        //cambiar estado del Rigibody2d a Kinematic 
        //Sacar lo que hace que el soldado salga de la barca al apuntar

        if(timeEmbarcar >= timeEmbarcarLimit)
        {
            //Player caracteristicas
            playerRb2d.bodyType = RigidbodyType2D.Kinematic;
            followBarcaPlayer.enabled = true;
            movimientoPlayer.enabled = false;
            stairsPlayer.enabled = false;
            //Habilitar armas del Player
            bloqPlayer.HabilitarPlayerBarco();
            //Orientar al Player 
            player.transform.localScale = new Vector3(horientacionBarco, 1, 1);
            //La barca aparece, ya que has embarcado
            barca.SetActive(true);
            //Coloca la barca
            barca.transform.position = barcaSpawn.transform.position;
            //Inhabilitar el botton
            buttonBarco.UsosGastados();
            //Colocar la Camera
            mainCamera.Follow = barca.transform;
            //Llamar de nuevo a la Transicion
            AnimationHud.detectar_echar.SetBool("Transicion", false);
            //Apagar el putBarco
            putBarco = false;
            //Resetea el tiempo para poder volver a usarlo
            timeEmbarcar = 0;
            //Hacia que direccion se coloca el barco
            barca.transform.localScale = new Vector3 (horientacionBarco, 1, 1);


        }
        else
        {
            //Inhabilitar el daño por Agua
            waterPoison.enabled = false;
            AnimationHud.detectar_echar.SetBool("Transicion", true);
            bloqPlayer.BloquearMovPlayer();
            timeEmbarcar += Time.deltaTime;
        }
    }
    void EmbarcarTrigger()
    {
        if(waterInfo.porcentajeAgua <= 0)
        {
            colliderEmbarcar.enabled = false;
        }
        else
        {
            colliderEmbarcar.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName)) useBarco = true;
        if (collision.gameObject.CompareTag("Player")) playerRange = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName)) useBarco = true;
        if (collision.gameObject.CompareTag("Player")) playerRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName)) useBarco = false;
        if (collision.gameObject.CompareTag("Player")) playerRange = false;
    }
}
