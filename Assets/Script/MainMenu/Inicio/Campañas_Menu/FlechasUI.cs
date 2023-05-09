using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechasUI : MonoBehaviour
{
    [Header("Flechas")]
    [SerializeField] GameObject flechaIzq;
    [SerializeField] GameObject flechaDrcha;
    [Header("CampaignMain")]
    public ListCampaign listaCampaignMain;

    // Update is called once per frame
    void Update()
    {
        ReglasFlechas();
    }
    void ReglasFlechas()
    {
        if(listaCampaignMain.indexCampaign == 0)
        {
            flechaIzq.SetActive(false);
        }
        else if (listaCampaignMain.indexCampaign != 0)
        {
            flechaIzq.SetActive(true);
        }
        if(listaCampaignMain.indexCampaign == listaCampaignMain.listaCampaign.Count - 1)
        {
            flechaDrcha.SetActive(false);
        }
        else if (listaCampaignMain.indexCampaign < listaCampaignMain.listaCampaign.Count - 1)
        {
            flechaDrcha.SetActive(true);
        }
    }
}
