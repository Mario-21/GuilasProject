using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobrecarga : MonoBehaviour
{
    public int indexAparato;
    public int indexGenerador;

    public List<int> indexSoldados;

    public int cargaElectrica;
    bool canOffAparato;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Quieres que solo se haga una vez al tocar el cambio de turno
        Demo_Turnos offDispositivos = new Demo_Turnos();
        offDispositivos.OffAparatosTurnos(indexSoldados, ref canOffAparato);
        //Si los soldados asociados estan vivos, el aparato se puede apagar.
        //Si el generador no esta a punto de sobrecargarse, se puede apagar.
        //Si el aparato esta encendido, se puede apagar.
        if (canOffAparato &&
            !StatusGameobjectsVariables.statusGameobject.modificacion[indexGenerador].modificacion &&
            StatusGameobjectsVariables.statusGameobject.modificacion[indexAparato].modificacion) 
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexAparato].modificacion = false;
            ExtraVariable.extras.valorGenerador -= cargaElectrica;
        }
    }
}
