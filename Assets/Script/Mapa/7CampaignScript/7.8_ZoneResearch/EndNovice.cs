using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNovice : MonoBehaviour
{
    public int indexTimeExceed;
    public int indexFinishCinematic;
    [SerializeField] Aparecer_DesAp_Obj ap_des;

    void Start()
    {
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexTimeExceed].modificacion &&
           StatusGameobjectsVariables.statusGameobject.modificacion[indexFinishCinematic].modificacion)
        {
            ap_des.enabled = true;
        }
    }

}
