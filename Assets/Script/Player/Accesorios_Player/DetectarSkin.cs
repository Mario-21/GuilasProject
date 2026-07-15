using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarSkin : MonoBehaviour
{
    public ChangeSkinPlayer skinEquipada;
    public SpawnTutoGame tutoGameEquipado;
    void Update()
    {
        if (skinEquipada.putSkin)
        {
            tutoGameEquipado.enabled = true;
        }
    }
}
