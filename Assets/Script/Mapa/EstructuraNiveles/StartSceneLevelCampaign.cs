using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneLevelCampaign : MonoBehaviour
{
    public static StartSceneLevelCampaign infoActualCampaign;

    public int firstActualSceneCampaign;
    public string nombrePrimeraEscenaNivel;
    private void Awake()
    {
        if (StartSceneLevelCampaign.infoActualCampaign == null)
        {
            StartSceneLevelCampaign.infoActualCampaign = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
