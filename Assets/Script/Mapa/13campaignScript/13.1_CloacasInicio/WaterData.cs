using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterData : MonoBehaviour
{
    public int indexWater;
    [Header("Porcentaje Agua")]
    public int porcentajeAgua = 100;
    [Header("Alturas Agua")]
    public Transform alturaMax; 
    public Transform alturaMin;
    [Header("Particulas Chapoteo")]
    public GameObject chapoteoParticle;

    public float alturaTotal;
    float aguaRestar;
    void Awake()
    {
        alturaTotal = alturaMax.position.y - alturaMin.position.y;
    }
    private void Start()
    {
        LoadWater();
    }
    private void Update()
    {
        if(transform.position.y > alturaMax.position.y)
        {
            transform.position = new Vector3(transform.position.x, alturaMax.position.y, transform.position.z);
        }
        LimitarPorcentajeAgua();
    }
    void LimitarPorcentajeAgua()
    {
        if(porcentajeAgua >= 100)
        {
            porcentajeAgua = 100;
        }
    }
    void LoadWater()
    {
        //aguaRestar = (porcentajeAgua * waterAltTotal.alturaTotal) / 100;
        porcentajeAgua = ListWaters.listWaters.infoAguas[indexWater].porcentajeAgua;


        //Quiza se puede quitar la altura minima 
        aguaRestar = (ListWaters.listWaters.infoAguas[indexWater].porcentajeAgua * alturaTotal) / 100;
        float alturaWater;
        alturaWater = alturaMin.position.y + aguaRestar;
        transform.position = new Vector3(transform.position.x, alturaWater, transform.position.z);
        //Minimo del Agua = -18.47
        //10.216 = Altura ==> 4.0864
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform ubiPlayerAgua = collision.gameObject.transform;

            Vector3 ubiPlayerFake = ubiPlayerAgua.position + (Vector3.down / 2);

            Instantiate(chapoteoParticle,ubiPlayerFake, ubiPlayerAgua.rotation);
        }
    }
}
