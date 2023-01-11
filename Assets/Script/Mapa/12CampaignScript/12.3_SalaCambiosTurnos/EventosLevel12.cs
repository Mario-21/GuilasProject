using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EventosLevel12
{
    public enum TypeEvent
    {
        Explosion,
        Overcharge,
        TanqueAgua
    }
    public TypeEvent tipoEvento;

}
class Explosion : EventosLevel12
{
    public void ShakeExplosion(CinemachineVirtualCamera mainCamera, ref float magnitudShake, ref float timeShake, float timeShakeLimit)
    {
        //Una vez endShake termine, si se da el caso de querer agitar otra vez la camara, puedes hacerlo
        mainCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = magnitudShake;
        if (timeShake < timeShakeLimit)
        {
            timeShake += Time.deltaTime;
        }
        else
        {
            if (magnitudShake <= 0)
            {
                magnitudShake = 0;
            }
            else
            {
                magnitudShake -= 0.01f;
            }
        }

    }
        
}
class Overcharge : EventosLevel12 
{
    /// <summary>
    /// Parpadeara la luz para indicar que el evento se realizado
    /// </summary>
    /// <param name="objeto"> aparecer desaparecer algo</param>
    /// <param name="tiempo"> Tiempo actual de la accion</param>
    /// <param name="maxTiempo"> Tiempo máximo de la accion</param>
    /// <param name="conteo"> Conteo del numero de veces que se repite la accion</param>
    /// <param name="conteoMaximo"> Cuantas veces quieres que se repita como máximos</param>
    public void BlinkLight(GameObject objeto, ref float tiempo, float maxTiempo,  ref int conteo, int conteoMaximo)
    {
        if(tiempo < maxTiempo) tiempo += Time.deltaTime;
        for (int i = 0; conteo < conteoMaximo && tiempo >= maxTiempo; conteo++)
        {
            int total = conteo % 2;
            tiempo = 0;
            Debug.Log("Soy el conteo y es de " + conteo);
            if (total == 0)
            {
                objeto.SetActive(false);
            }
            else
            {
                i++;
                objeto.SetActive(true);
            }
        }
    }
}
class TanqueAgua : EventosLevel12
{
    public void WaterBreakTank(GameObject goteo)
    {
        goteo.SetActive(true);
    }
}

