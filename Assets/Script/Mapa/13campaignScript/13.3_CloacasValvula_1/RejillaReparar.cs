using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejillaReparar : MonoBehaviour
{
    public int indexMod;

    public int indexDataAgua;
    public Transform aguaPos;
    public Transform alturaMin;
    [Header("Lista Valvulas Activar")]
    [SerializeField] List<Valvula> valvulasReactivar;
    [SerializeField] int numTotalValvulas;
    void Start()
    {
        
    }

    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            foreach(Valvula valve in valvulasReactivar)
            {
                valve.enabled = true;
                numTotalValvulas++;
            }
            if(numTotalValvulas >= valvulasReactivar.Count) this.enabled = false;
        }
        else
        {
            ListWaters.listWaters.infoAguas[indexDataAgua].porcentajeAgua = 0;
            aguaPos.position = new Vector3(aguaPos.position.x, alturaMin.position.y, aguaPos.position.z);
        }
    }
}
