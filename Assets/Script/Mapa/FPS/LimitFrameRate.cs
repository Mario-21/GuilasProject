using UnityEngine;

public class LimitFrameRate : MonoBehaviour
{
    // Start is called before the first frame update

    public int target = 60;

    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
}
