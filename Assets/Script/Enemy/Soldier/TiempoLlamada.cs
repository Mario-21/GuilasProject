using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoLlamada : MonoBehaviour
{
    [SerializeField] SpriteRenderer marcoTiempo;

    public float tiempoLlamada;
    public float tiempoLlamadaLimite;

    public float sizeX;

    public bool encenderAccion;

    float conversorTiempo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoLlamada < tiempoLlamadaLimite)
        {
            conversorTiempo = tiempoLlamada * sizeX / tiempoLlamadaLimite;

            //conversorTiempo = tiempoLlamada / tiempoLlamadaLimite;
            marcoTiempo.size = new Vector2(conversorTiempo, marcoTiempo.size.y);

            if (encenderAccion)
            {
                tiempoLlamada += Time.deltaTime;
            }
        }
        else
        {
            Debug.Log("Tiempo Completado");
        }
    }
}
