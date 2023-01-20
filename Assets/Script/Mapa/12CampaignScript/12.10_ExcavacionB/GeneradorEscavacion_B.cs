using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GeneradorEscavacion_B : MonoBehaviour
{
    public int indexMod;

    public int valorElectricoMaximo;

    [Tooltip("Se necesita una barra para poder ver a cuanto progeso tiene el generador")]
    public Image barraGenerador;

    public static float barraGenNumber;
    void Update()
    {
        barraGenerador.fillAmount = barraGenNumber;
        Debug.Log("El fill Amount es " + barraGenNumber);   

        ColorGenerador();

        if (ExtraVariable.extras.valorGenerador >= valorElectricoMaximo) 
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
        else
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = false;
        }
        //No puede llegar a ser menor que cero
        if(ExtraVariable.extras.valorGenerador <= 0)
        {
            ExtraVariable.extras.valorGenerador = 0;
        }
    }
    void ColorGenerador()
    {
        if(barraGenerador.fillAmount <= 0.5)
        {
            barraGenerador.color = Color.green;
        }
        else if(barraGenerador.fillAmount > 0.5 && barraGenerador.fillAmount <= 0.8)
        {
            barraGenerador.color = Color.yellow;
        }
        else
        {
            barraGenerador.color = Color.red;
        }
    }
    public static void IncrementoGenerador(float incremento)
    {
        barraGenNumber += incremento;
    }
    public static void DecrementoGenerador(float decremento)
    {
        barraGenNumber -= decremento;

    }
}
