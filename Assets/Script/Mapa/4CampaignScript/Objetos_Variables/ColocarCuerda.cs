using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarCuerda : MonoBehaviour
{
    [Tooltip("Identity is number of modification")]
    public int indexMod;
    ActivarModificador activar;
    [SerializeField] GameObject colocarItem;
    void Start()
    {
        activar = GetComponent<ActivarModificador>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ColocarItem();
        }
    }

    void Update()
    {
        //Simula que colocas un objeto,activando uno ya presente en escena
        if (activar.modificacion) ColocarItem();
    }
    void ColocarItem()
    {
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        colocarItem.SetActive(true);
        //Se desactiva para que no puedas a volver a realizar la acción y no te quite uses a los objetos si tienen más de un uso
        this.enabled = false;
    }
}
