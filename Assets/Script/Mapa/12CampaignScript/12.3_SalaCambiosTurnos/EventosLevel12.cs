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
    public void ConfirmEvent(int index) 
    {
        StatusGameobjectsVariables.statusGameobject.modificacion[index].modificacion = true;
    }
    //Nota pedir a cada uno un numero para saber cual de todos los eventos es
    //Una lista con cada uno de los index correspondiente a cada evento
    //Compara el index pedido con el de la las lista y cuando llegue a uno que se igual, le dice este mi evento
    public virtual void SelectEvent(List<int> listEvent, int indexEvent, TypeEvent type)
    {
        for (int i = 0; i < listEvent.Count; i++)
        {
            if(listEvent[i] == indexEvent)
            {
                Debug.Log("Soy el evento" + type);
            }
        }
    }
    public void ChooseEvent(int numEvent)
    {
        switch (numEvent)
        {
            case 0:
                tipoEvento = TypeEvent.Explosion;
                break;
            case 1:
                tipoEvento = TypeEvent.Overcharge;
                break;
            case 2:
                tipoEvento = TypeEvent.TanqueAgua;
                break;
        }
    }
}
class Explosion : EventosLevel12
{
    public override void SelectEvent(List<int> listEvent, int indexEvent, TypeEvent tipoEvento)
    {
        base.SelectEvent(listEvent, indexEvent, tipoEvento);
       
    }
    public void ShakeExplosion(CinemachineVirtualCamera mainCamera, float magnitudShake)
    {
        mainCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = magnitudShake;
    }
        
}
class Overcharge : EventosLevel12 
{
    /// <summary>
    /// Parpadeara la luz para indicar que el evento se realizado
    /// </summary>
    /// <param name="light"> Luz que parpadea</param>
    /// <param name="timeBlink"> Tiempo actual del parpadeo</param>
    /// <param name="timeBlinkLimit"> Tiempo máximo de cada parpadeo</param>
    /// <param name="countBlink"> Conteo del parpadeo</param>
    /// <param name="countBlinkLimit"> Cuantos parpadeos máximos da</param>
    /// 

    //Probar esto con un public override, porque es la unica diferencia que hay con el Demoturnos
    public void BlinkLight(GameObject light, ref int countBlink, ref float tiempo)
    {
        tiempo += Time.deltaTime;
        for(countBlink = 0; countBlink < 9; countBlink++)
        {
            Debug.Log("Lost and Them " + countBlink);
        }
        //El numero de conteoBlink debe ser par, para dejar encendida la luz.
        //Contara en un bucle cuantos parpadeos debe dar en <<X>> tiempo
        /*int total = countBlink % 2;
        Debug.Log("El resto del total " + total);

        if (total == 0)
        {
            light.SetActive(false);
        }
        else
        {
            light.SetActive(true);
        }*/
    }
}
class TanqueAgua : EventosLevel12
{
    public void WaterBreakTank(GameObject goteo)
    {
        goteo.SetActive(true);
    }
}

