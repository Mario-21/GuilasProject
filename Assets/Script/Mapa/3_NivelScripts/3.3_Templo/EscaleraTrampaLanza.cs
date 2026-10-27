using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscaleraTrampaLanza : MonoBehaviour
{
    // Start is called before the first frame update
    public List<DefinicionTrampaLanza> definicionTrampaLanza;
    public int numeroTotalLanzas;
    float resetearTimer = 0;
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        if(numeroTotalLanzas == definicionTrampaLanza.Count)
		{
			ResetearTrampaEscalera();
		}
    }
    public void CheckearLanzas()
    {
		for (int e = 0; e < definicionTrampaLanza.Count; e++)
		{
			//Revisa dentro de la lista cual a llegado a su posicion original, osea, ha terminado el ciclo de que la trampa se active
			if (definicionTrampaLanza[e].trampaLanza.posOrigen)
			{
				//Ahora hay que revisar que dentro de la misma lista no haya sido llamada una primera, para evitar un exceso en el conteo
				if(!definicionTrampaLanza[e].lanzaActivaEscalera)
				{
					//Incrementa para saber cuando voy a tener que resetear y volver a hacer la escalera
					numeroTotalLanzas++;
					//Lo desactivas para asegurarte de que no se va a descuadrar el ciclo de la escalera 
					definicionTrampaLanza[e].trampaLanza.enabled = false;
					//Reseteas el Timer de las trampas de las lanzas para asegurarte de que se va a ejecutar a tiempo.
					definicionTrampaLanza[e].trampaLanza.tiempoActivarTrampa = 0;
					//Esto es para que me permita sacarlo de la lista, pero sin sacarlo de la lista
					definicionTrampaLanza[e].lanzaActivaEscalera = true;

				}
			}

		}
	}
	void ResetearTrampaEscalera()
	{
		foreach(DefinicionTrampaLanza defTrampaLanza in definicionTrampaLanza)
		{
			defTrampaLanza.trampaLanza.enabled = true;
			//Debug.Log("Se ha reseteado la trampa " + defTrampaLanza.name);
		}
		numeroTotalLanzas = 0;
	}
}
