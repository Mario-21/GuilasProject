using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffCameras : MonoBehaviour
{
    public int indexMod;

    PlayerHere player;
    [Header("Cameras")]
    [SerializeField] List<GameObject> camaras;
    [Header("Boton Change Color")]
    [SerializeField] SpriteRenderer botonCameras;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            //Apaga las Camaras
            ApagarCamaras();
            //Cambia Color del boton para identificar que las camaras estan apagadas
            ChangeStatusBoton();
            //Desactiva el script
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UsarBotonCamaras();
    }
    void UsarBotonCamaras()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ApagarCamaras();
                ChangeStatusBoton();
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            }
        }
    }
    void ApagarCamaras()
    {
        foreach (GameObject luzCamera in camaras)
        {
            luzCamera.SetActive(false);
        }
    }
    void ChangeStatusBoton()
    {
        botonCameras.color = Color.red;
    }
}
