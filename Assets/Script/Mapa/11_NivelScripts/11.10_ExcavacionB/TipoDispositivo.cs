using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipoDispositivo
{
    public void GastoElectrico(ref int valorTotal, int valorGasto, ref bool deviceStatus) //ref int once
    {
        if (deviceStatus)
        {
            valorTotal += valorGasto;
            float incremento = (float)valorGasto / 100;
            GeneradorEscavacion_B.IncrementoGenerador(incremento);
        }
        else
        {
            valorTotal -= valorGasto;
            float decremento = (float)valorGasto / 100;
            GeneradorEscavacion_B.DecrementoGenerador(decremento);
        }

    }
}
class Taladro : TipoDispositivo
{
    public void UseTaladro(ref bool encender, Animator animTaladro,GameObject particlesDrill)
    {
        if (encender)
        {
            //Taladro Activar la animacion
            animTaladro.enabled = true;
            particlesDrill.SetActive(true);
            
        }
        else
        {
            animTaladro.enabled = false;
            particlesDrill.SetActive(false);
        }
    }
}
class Ventilador : TipoDispositivo
{
    public void UseVentilador(ref bool encender, GameObject baseVentilador, float velocidad)
    {
        if (encender)
        {
            baseVentilador.transform.Rotate(0, baseVentilador.transform.position.y + velocidad, 0);
        }
        else
        {
            baseVentilador.transform.Rotate(0, 0, 0);
        }
    }
}
class Foco : TipoDispositivo
{
    public void UseFoco(ref bool encender, GameObject luz)
    {
        if (encender)
        {
            luz.SetActive(true);
        }
        else
        {
            luz.SetActive(false);
        }
    }
}
