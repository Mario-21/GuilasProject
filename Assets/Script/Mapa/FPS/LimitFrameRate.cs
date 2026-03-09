using UnityEngine;

public class LimitFrameRate : MonoBehaviour
{
    // Start is called before the first frame update

    public int target = 60;

    [Range(0,4)]
    public int qualitySetting;

    public enum FrameRateTipo
    {
        Pantalla,
        Personalizado
    }
    public FrameRateTipo tipoFrame;

    void Start()
    {
        QualitySettings.vSyncCount = qualitySetting;
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        //Application.targetFrameRate = -1;
        print(Screen.currentResolution);
    }
    private void Update()
    {
        switch (tipoFrame)
        {
            case FrameRateTipo.Pantalla:
                break;
            case FrameRateTipo.Personalizado:
                Application.targetFrameRate = target;
                break;
        }
    }
}
