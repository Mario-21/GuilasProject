using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterData : MonoBehaviour
{
    public int indexWater;
    [Header("Alturas Agua")]
    public Transform alturaMax; 
    public Transform alturaMin;

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
    }
    private void OnDestroy()
    {
        SaveWater();
    }
    void SaveWater()
    {
        ListWaters.listWaters.indexLevelWater[indexWater] = transform.position.y;
    }
    void LoadWater()
    {
        transform.position = new Vector3 (transform.position.x,ListWaters.listWaters.indexLevelWater[indexWater], transform.position.z);
    }
}
