using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldadoProfundo : MonoBehaviour
{
    [Header("Data Soldado Sprite")]
    [SerializeField] SpriteRenderer soldado;
    [SerializeField] Sprite[] perspectiva;
    [Header("Ubicaciones Mover Soldado")]
    [SerializeField] Transform[] ubicaciones;
    int indexUbi;
    [Header("Time Espera Soldado")]
    public float timeWaitLimite;
    float timeWait;
    [Header("Velocidad Soldado")]
    public float velocidad;
    [Header("Size Soldado al Alejarse/Acercarse")]
    public float size;
    public float sizeLimit;

    public float distancia;

    bool frente;

    [SerializeField] BoxCollider2D detector;
    void Start()
    {
        PerspectivaSoldado();
    }

    // Update is called once per frame
    void Update()
    {
        //distancia = DistancePointZ().y;
        CambiarSize();
        MoveProfundidad();
    }
    void MoveProfundidad()
    {
        if(indexUbi < ubicaciones.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, ubicaciones[indexUbi].position, velocidad * Time.deltaTime);
            if (Vector3.Distance(ubicaciones[indexUbi].position, transform.position) < 0.1)
            {
                timeWait += Time.deltaTime;
                if (timeWait >= timeWaitLimite)
                {
                    timeWait = 0;
                    indexUbi++;
                    PerspectivaSoldado();

                }
            }
        }
        else if (indexUbi >= ubicaciones.Length)
        {
            //soldado.sprite = perspectiva[0];
            indexUbi = 0;
            PerspectivaSoldado();
        }

    }
    void PerspectivaSoldado()
    {
        if(indexUbi < ubicaciones.Length)
        {
            distancia = DistancePointZ().y;
            if (DistancePointZ().y < 0)
            {
                //Colocar Animacion de giro
                //De frente 
                detector.enabled = true;
                soldado.sprite = perspectiva[0];
                frente = true;
            }
            else
            {
                //De espalda
                detector.enabled = false;
                soldado.sprite = perspectiva[1];
                frente = false;
            }
        }
        
    }
    void CambiarSize()
    {
        if (indexUbi < ubicaciones.Length)
        {
            distancia = DistancePointZ().y;
            if (DistancePointZ().y < 0)
            {
                //Me acerco
                if(transform.localScale.x < 1 && frente)
                {
                    transform.localScale = new Vector3(transform.localScale.x + size, transform.localScale.y + size, transform.localScale.z + size);
                }
            }
            else
            {
                //Me alejo
                if (transform.localScale.x > sizeLimit && !frente)
                {
                    transform.localScale = new Vector3(transform.localScale.x - size, transform.localScale.y - size, transform.localScale.z - size);
                }
            }
        }
    }
    Vector3 DistancePointZ()
    {
        Vector3 distanceZ;
        return distanceZ = ubicaciones[indexUbi].position - transform.position;

    }
}
