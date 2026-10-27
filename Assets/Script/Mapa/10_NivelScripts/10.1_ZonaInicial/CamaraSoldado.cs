using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSoldado : MonoBehaviour
{
    public int indexSoldadoGuardia;

    [SerializeField] List<Detectar_y_Echar_Cameras> listCameras;
    int conteoCamerasDesactivadas;
    void Start()
    {
        DesactivarCamarasPorSoldado();
    }

    // Update is called once per frame
    void Update()
    {
        DesactivarCamarasPorSoldado();
    }
    void DesactivarCamarasPorSoldado()
    {
        if (SoldierActiveInScene.instancia.soldiersStatus[indexSoldadoGuardia].statusVida <= 0)
        {
            foreach (Detectar_y_Echar_Cameras cameraEchar in listCameras)
            {
                cameraEchar.enabled = false;
                conteoCamerasDesactivadas++;
            }
            if (conteoCamerasDesactivadas >= listCameras.Count)
            {
                this.enabled = false;
            }
        }
    }
}
