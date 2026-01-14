using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoDetectorParedes : MonoBehaviour
{
    //RaycastHit2D distancia;
    //distancia = Physics2D.Raycast(transform.position, DistancenPlayer().normalized, rayDistancePlayer,playerMask);
    [Header("Distancias Datos")]
    public Transform player;
    public Transform yoEnemigo;
    public float outRangeEnemigo;
    public float alturaEnemigo;

    public float distanciaPlayerNormalize;
    public Vector2 distanciaAbsoluta;

    [SerializeField] LayerMask maskGeneral;
    [SerializeField] LayerMask maskGround;
    [SerializeField] LayerMask maskPlayer;

    Color colorRayo;
    public bool bloqueoPared;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //distanciaAbsoluta = DistanciaPlayerAbsoluta();
        MagnitudAbsolutaPlayer();
        if (MagnitudAbsolutaPlayer() <= outRangeEnemigo) 
        {
            Debug.DrawRay(yoEnemigo.position, MedirDistanciaPlayer(), colorRayo);
            if(MagnitudAbsolutaPlayer() <= alturaEnemigo )Rayos_2();
        }
    }
    void Rayos()
    {
        RaycastHit2D distanciaPlayerRay;
        distanciaPlayerRay = Physics2D.Raycast(yoEnemigo.position, MedirDistanciaPlayer(), MagnitudAbsolutaPlayer(), maskGeneral);

        if (distanciaPlayerRay)
        {
            colorRayo = Color.green;
        }
        else
        {
            colorRayo = Color.red;
        }

        Debug.DrawRay(yoEnemigo.position, MedirDistanciaPlayer(), colorRayo);
    }
    void Rayos_2()
    {
        RaycastHit2D distanciaEnemyPlayer;
        distanciaEnemyPlayer = Physics2D.Raycast(yoEnemigo.position, MedirDistanciaPlayer(), MagnitudAbsolutaPlayer(), maskPlayer);
        RaycastHit2D distanciaEnemyGround;
        distanciaEnemyGround = Physics2D.Raycast(yoEnemigo.position, MedirDistanciaPlayer(), MagnitudAbsolutaPlayer(), maskGround);

        //Si se activa los dos distanciaEnemyPlayer y distanciaEnemyGround quiere decir que hay algo delante bloqueando el camino, lo que implica que no se pueda activar 
        //el detectar al player.

        if(distanciaEnemyPlayer && distanciaEnemyGround)
        {
            colorRayo = Color.red;
            bloqueoPared = true;
        }
        else
        {
            colorRayo = Color.green;
            bloqueoPared = false;
        }

    }

    Vector2 MedirDistanciaPlayer()
    {
        Vector2 medirdistanciaPlayer;
        return medirdistanciaPlayer = player.position - yoEnemigo.position;
    }
    Vector2 DistanciaPlayerAbsoluta()
    {
        Vector2 distanciaPlayerAbsoluta;
        return distanciaPlayerAbsoluta = new Vector2 (Mathf.Abs(MedirDistanciaPlayer().x), Mathf.Abs(MedirDistanciaPlayer().y));
    }
    float MagnitudAbsolutaPlayer()
    {
        return distanciaPlayerNormalize = Mathf.Abs(MedirDistanciaPlayer().magnitude);
    }
    Vector2 NormalizarDistanciaPlayer()
    {
        Vector2 distanciaPlayerNormalized;
        return distanciaPlayerNormalized = MedirDistanciaPlayer().normalized;
    }
}
