using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutEmbarques : MonoBehaviour
{
    //Pedir el agua de la zona
    [SerializeField] WaterData waterInfo;
    //Si esta es >0 aparecen los embarques
    [SerializeField] List<GameObject> embarques;
    //Por debajo o igual aparecen de nuevo
    //Esto se hace para que no uses el trigger en el suelo de colocar el barco
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AguaOutEmbarque();
    }
    void AguaOutEmbarque()
    {
        if(waterInfo.porcentajeAgua > 0)
        {
            for(int e = 0; e < embarques.Count; e++)
            {
                embarques[e].SetActive(true);
            }
        }
        else if (waterInfo.porcentajeAgua <= 0)
        {
            for (int e = 0; e < embarques.Count; e++)
            {
                embarques[e].SetActive(false);
            }
        }
    }
}
