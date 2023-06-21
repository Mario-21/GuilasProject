using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveWater : MonoBehaviour
{
    public List<int> waterStart;
    void Start()
    {
        for(int e = 0; e < waterStart.Count; e++)
        {
            waterStart[e] = ListWaters.listWaters.infoAguas[e].porcentajeAgua;
        }
    }
    public void ResetearWater()
    {
        for(int w = 0; w < waterStart.Count; w++)
        {
            if(ListWaters.listWaters.infoAguas[w].porcentajeAgua != waterStart[w])
            {
                ListWaters.listWaters.infoAguas[w].porcentajeAgua = waterStart[w];
            }
        }
    }
}
