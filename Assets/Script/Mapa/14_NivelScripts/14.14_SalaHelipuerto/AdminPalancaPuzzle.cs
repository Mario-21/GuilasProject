using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class AdminPalancaPuzzle : MonoBehaviour
{
    public int indexMod;

    [Header("Solucion Puzle")]
    public int codigoPuzleSolucion;
    public GameObject completarPuzle;
    public string codigoString;

    public int digitosClotheData;
    int digitosCodigoSolucion;
    [Header("Error Puzle")]
    [SerializeField] List<PalancaPuzzle> palancas;
    [SerializeField] EventReference errorPuzle;
    void Start()
    {
        //Si ya has completado el puzle, desactivalo
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
        //Establece el número total de digitos que tiene la solucion del codigo
        foreach (char digito in codigoPuzleSolucion.ToString())
        {
            digitosCodigoSolucion++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Si se ha alcanzado a tocar todas las palancas, se revisará si has acertado o te has equivocado
        if(digitosClotheData == digitosCodigoSolucion)
        {
            //Acertar, colola la variable principal como completar y reproduce un sonido de confirmacion
            if(codigoPuzleSolucion == ClotheData.clotheInfo.numCloth)
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                //Reproducir sonido
                completarPuzle.SetActive(true);
                Debug.Log("Has completado el puzle");
                this.enabled = false;
            }
            //Equivocarse, resetea todas las variables y el estado de las palancas
            else
            {
                //Resetea el ClotheData
                ClotheData.clotheInfo.numCloth = 0;
                //codigoString se resetea
                codigoString = "";
                //Los digitosClotheData se resetean
                digitosClotheData = 0;
                //Reproducir Sonido de Palanca subida
                AudioManager.instancia.PlayOneShot(errorPuzle);
                //Resetear todas las palancas
                foreach (PalancaPuzzle palancaPuzle in palancas)
                {
                    StatusGameobjectsVariables.statusGameobject.modificacion[palancaPuzle.indexMod].modificacion = false;
                    palancaPuzle.enabled = true;
                    palancaPuzle.palancaMant.enabled = true;
                    palancaPuzle.palancaMant.ResetearPalanca();
                }



            }
        }
    }
}
