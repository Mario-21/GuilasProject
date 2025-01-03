using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesUIControler : MonoBehaviour
{
    public void AparecerCanvas(GameObject apCanvas)
    {
        apCanvas.SetActive(true);
    }
    public void DesaparecerCanvas(GameObject desCanvas)
    {
        desCanvas.SetActive(false);
        DataPersistenceManager.instance.SaveGameNoEncrypt();
        Debug.Log("Salvada");
    }
}
