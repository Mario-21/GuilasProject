using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoraDescanso : MonoBehaviour
{
    public int indexMod;
    public List<SoldierLife> soldadoDescanso;
    void Start()
    {
        //Cuando la variable se activa, revisará si los soldados estan vivos o no para que se vayan a descansar
        Demo_Turnos demoTurnos = new Demo_Turnos();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            demoTurnos.DescansoSinTurnos(soldadoDescanso);
        }
    }
}
