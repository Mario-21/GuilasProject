using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetearObjetosTurnos : MonoBehaviour
{
    [Header("Variables Soldados")]
    public int indexEstadoSoldados;
    [Header("Variables que quiero cambiar")]
    public List<InformeVariables> variablesCambiar;
    [Header("Turno Informe")]
    [Tooltip("En que turno quieres que se anulen las variables")]
    public int casoTurnoRequerido;

    void Start()
    {
        //Primero comprobar si los soldados estan vivos o no, en base a esto puedes determinar si al cambiar de turno tengo reiniciar todas las variables que quiero cambiar o no
        //DevolverObjetos, para devolver un objeto se debe revisar los usos de los objetos, si ya se han usado pero su respectiva variable no se ha activado, significa que alguien te los quitado, por tanto,
        //tiene que reaparecer para que puedas recogerlos.
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexEstadoSoldados].modificacion)
        {
            //Esto se hace así para poder luego aplicar un aparecer y desaparecer, porque aun sobreviviendo se siguen reseteando las variables. En el caso de la explosion provocaría que la carcasa aparecíera constantemente
            //para la dinamita incolora te da igual en caso de usar la roja, pero con la carcasa no.
            Invoke("ResetearVariablesTurnoCambiado", 0.5f);
        }
    }
    void ResetearVariablesTurnoCambiado() 
    {
        if(TurnosWorked.extras.turnosWork != casoTurnoRequerido)
        {
            for(int i = 0; i < variablesCambiar.Count; i++)
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[variablesCambiar[i].indexVariable].modificacion = false;
            }

        }
    }

}
[System.Serializable]
public class InformeVariables
{
    public string nombreVariable;
    public int indexVariable;
}
