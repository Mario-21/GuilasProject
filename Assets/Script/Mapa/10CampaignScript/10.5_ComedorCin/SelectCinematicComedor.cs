using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SelectCinematicComedor : MonoBehaviour
{
    [Header("Camera Data")]
    [SerializeField] CinemachineVirtualCamera mainCamera;

    [Header("Aspersor Cinematic")]
    [SerializeField] Transform ubiAspersor;
    [SerializeField] ReviveChef reviveChef;
    [SerializeField] AngryChef angryChef;
    [SerializeField] AspersorOn aspersorOn;
    [SerializeField] List<GameObject> listEnemyAsp;
    

    [Header("Veneno Cinematic")]
    [SerializeField] Transform ubiVeneno;
    [SerializeField] PoisonDrink poisonDrink;
    [SerializeField] AngryChef helpSoldier;
    [SerializeField] List<GameObject> listEnemyVen;
    void Awake()
    {
        switch (ExtraVariable.extras.comedorScene)
        {
            case ExtraVariable.CinematicComedor105.Aspersor:
                //Coloca los datos de la camara
                mainCamera.Follow = ubiAspersor;
                mainCamera.m_Lens.OrthographicSize = 3;
                //Muestra los enemigos que se usaran en la cinematica Aspersores
                foreach(GameObject soldadoCin in listEnemyAsp)
                {
                    soldadoCin.SetActive(true);
                }
                //Activa los script pertenecientes a la cinematica Aspersores
                reviveChef.enabled = true;
                aspersorOn.enabled = true;
                angryChef.enabled = true;
                break;

            case ExtraVariable.CinematicComedor105.Veneno:
                //Coloca los datos de la camara
                mainCamera.Follow = ubiVeneno;
                mainCamera.m_Lens.OrthographicSize = 4;
                //Muestra los enemigos que se usaran en la cinematica Veneno
                foreach (GameObject soldadoCin in listEnemyVen)
                {
                    soldadoCin.SetActive(true);
                }
                //Activa los script pertenecientes a la cinematica Veneno
                poisonDrink.enabled = true;
                helpSoldier.enabled = true;
                //Colocar los 

                break;
        }
    }
}
