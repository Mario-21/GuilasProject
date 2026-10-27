using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnFocos : MonoBehaviour
{
    SoldadoNormal soldado;

    [Header("Generador Data")]
    [SerializeField] FocosGenerador generador;
    public Transform generadorUbi;
    public Transform defaultUbi;

    [Header("Tiempo En Comenzar a Marchar")]
    public float timeOnFocosLimit;
    float timeOnFocos;
    void Start()
    {
        soldado = GetComponent<SoldadoNormal>();
    }

    // Update is called once per frame
    void Update()
    {
        GoEnemyGenerator();
    }
    void GoEnemyGenerator()
    {
        if (!generador.focosOn)
        {
            //Esperara un poco, para comenzar la marcha 
            timeOnFocos += Time.deltaTime;
            if(timeOnFocos >= timeOnFocosLimit)
            {
                //Comienza la marcha
                soldado.ubicacionesDirigir[0] = generadorUbi;
            }
        }
        else
        {
            //Probar si va a necesitar esperar un poco de tiempo al cambiar de ubicación, por comodidad en el gameplay
            timeOnFocos = 0;
            soldado.ubicacionesDirigir[0] = defaultUbi;
        }
    }
}
