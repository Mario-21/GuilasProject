using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparatosApagados : MonoBehaviour
{
    public int indexAparato;
    public int indexGenerador;

    public List<int> indexSoldados;

    public int cargaElectrica;
    public bool canOffAparato;

    PlayerHere player;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        //Quieres que solo se haga una vez al tocar el cambio de turno
        Demo_Turnos offDispositivos = new Demo_Turnos();
        offDispositivos.OffAparatosTurnos(indexSoldados, ref canOffAparato);
        //Si el dispositivo esta apagado no hay necesidad de activar el script
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexAparato].modificacion)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Apagar();
            }
        }
    }
    void Apagar()
    {
        //Si los soldados asociados estan vivos, el aparato se puede apagar.
        //Si el generador no esta a punto de sobrecargarse, se puede apagar.
        //Si el aparato esta encendido, se puede apagar.
        if (canOffAparato &&
            !StatusGameobjectsVariables.statusGameobject.modificacion[indexGenerador].modificacion &&
            StatusGameobjectsVariables.statusGameobject.modificacion[indexAparato].modificacion)
        {
            //Se apaga el aparato, se resta la cantidad de energia
            StatusGameobjectsVariables.statusGameobject.modificacion[indexAparato].modificacion = false;
            ExtraVariable.extras.valorGenerador -= cargaElectrica;
            //Se resta en el fillAmount para que visualmente se vea que se ha restado
            float decrementoElect = (float)cargaElectrica / 100;
            GeneradorEscavacion_B.DecrementoGenerador(decrementoElect);
            //Inhabilitas el script
            this.enabled = false;
        }
    }
}
