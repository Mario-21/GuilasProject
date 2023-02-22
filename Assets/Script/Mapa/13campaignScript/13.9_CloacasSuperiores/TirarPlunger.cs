using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirarPlunger : MonoBehaviour
{
    public int indexDrenaje;
    public int indexMod;

    public GameObject itemCaer;
    void Start()
    {
        //Se muestra el objeto
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            itemCaer.SetActive(true);
        }
    }
    void Update()
    {
        //Si has activado el drenaje, el objeto que se ha quedado en la tubería cae
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenaje].modificacion)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
