using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListWaters : MonoBehaviour
{
    public static ListWaters listWaters;
    public List<PorcentajesAguas> infoAguas;

    [HideInInspector] public List<PorcentajesAguas> aguaPercentInicial;
    private void Awake()
    {
        if (ListWaters.listWaters == null)
        {
            ListWaters.listWaters = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        for(int i = 0; i < listWaters.infoAguas.Count; i++)
        {
            PorcentajesAguas aguaPercent = new PorcentajesAguas();

            aguaPercent.porcentajeAgua = listWaters.infoAguas[i].porcentajeAgua;
            aguaPercentInicial.Add(aguaPercent);
        }
    }
    public void ResetearAgua()
    {
        for (int i = 0; i < listWaters.infoAguas.Count; i++)
        {
            listWaters.infoAguas[i].porcentajeAgua = aguaPercentInicial[i].porcentajeAgua;
        }
    }

}
