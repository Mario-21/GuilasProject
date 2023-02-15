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
    private void OnDestroy()
    {
        SaveWater();
    }
    void SaveWater()
    {
        ListWaters.listWaters.infoAguas[indexWater].indexLevelWater = transform.position.y;
        ListWaters.listWaters.infoAguas[indexWater].porcentajeAgua = porcentajeAgua;
    }
    void LoadWater()
    {
        transform.position = new Vector3 (transform.position.x,ListWaters.listWaters.infoAguas[indexWater].indexLevelWater, transform.position.z);
        porcentajeAgua = ListWaters.listWaters.infoAguas[indexWater].porcentajeAgua;
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
