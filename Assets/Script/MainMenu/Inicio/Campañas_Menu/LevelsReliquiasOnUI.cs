using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsReliquiasOnUI : MonoBehaviour
{
    public ListCampaign listMainCampaign;
    public GameObject reliquiaContorno;
    public void CheckLevelReliquia()
    {
        if (!listMainCampaign.listaCampaign[listMainCampaign.indexCampaign].onReliquia)
        {
            reliquiaContorno.SetActive(false);
        }
        else
        {
            reliquiaContorno.SetActive(true);
        }
    }
}
