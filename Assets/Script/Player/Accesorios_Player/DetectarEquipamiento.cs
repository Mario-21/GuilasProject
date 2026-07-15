using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarEquipamiento : MonoBehaviour
{
    public PutGasMask equipo;
    public SpawnTutoGame tutoGameEquipado;
    void Update()
    {
        //En cuanto detecta que el objeto ha sido equipado, salta el tutorial
        if (equipo.putMask)
        {
            tutoGameEquipado.enabled = true;
        }
    }
}
