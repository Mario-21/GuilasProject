using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class AdminCamaraMultipleCin : MonoBehaviour
{
    public CinematicaEscena cinematicaEscena;
    public enum CinematicaEscena
    {
        A,
        B
    }
    public CinemachineVirtualCamera vCamMain;
    [Header("Cinemática A")]
    public int indexInicialA;
    public int indexModCinA;
    [SerializeField] GameObject objetoCinA;
    [SerializeField] Transform objectivoA;
    [Header("Cinemática B")]
    public int indexInicialB;
    public int indexModCinB;
    [SerializeField] GameObject objetoCinB;
    [SerializeField] Transform objectivoB;
    void Start()
    {
        //Esto solo determina que cinemática debe ejecutarse

        //Dependiendo de A o B vemos que cinemática se ejecuta.
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexInicialA].modificacion && !StatusGameobjectsVariables.statusGameobject.modificacion[indexModCinA].modificacion)
        {
            //PreviousState para evitar que la camara se quede pillada
            vCamMain.PreviousStateIsValid = false;
            //Colocar la camara mirando al objetivo A 
            vCamMain.Follow = objectivoA;
            //Establece cual es la escena
            cinematicaEscena = CinematicaEscena.A;
            //Hace visible el script que hace que la escena funcione
            objetoCinA.SetActive(true);
        }
        else if (StatusGameobjectsVariables.statusGameobject.modificacion[indexInicialB].modificacion && !StatusGameobjectsVariables.statusGameobject.modificacion[indexModCinB].modificacion)
        {
            //PreviousState para evitar que la camara se quede pillada
            vCamMain.PreviousStateIsValid = false;
            //Colocar la camara mirando al objetivo B
            vCamMain.Follow = objectivoB;
            //Establece cual es la escena
            cinematicaEscena = CinematicaEscena.B;
            //Hace visible el script que hace que la escena funcione
            objetoCinB.SetActive(true);
        }
    }

}
