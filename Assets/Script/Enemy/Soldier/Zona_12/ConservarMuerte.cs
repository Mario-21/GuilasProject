using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConservarMuerte : MonoBehaviour
{
    SoldierLife vidaSoldado;
    ActualStatus actualStatus;
    private void Awake()
    {
        actualStatus = GetComponent<ActualStatus>();
        vidaSoldado = GetComponent<SoldierLife>();
    }
    void Start()
    {
        //Si coincide con la escena actual aparece
        if(SoldierActiveInScene.instancia.soldiersStatus[actualStatus.iD].deathScene == SceneManager.GetActiveScene().buildIndex)
        {
            vidaSoldado.gameObject.SetActive(true);
            Debug.Log("Estas en la misma escena en la que el " + vidaSoldado.gameObject.name + " ha muerto");
        }
        //Si no estas en la misma escena y no estas muerto no aparezcas
        else if(SoldierActiveInScene.instancia.soldiersStatus[actualStatus.iD].deathScene != SceneManager.GetActiveScene().buildIndex && vidaSoldado.vida <= 0)
        {
            vidaSoldado.gameObject.SetActive(false);
            Debug.Log("El " + vidaSoldado.gameObject.name + "no ha muerto en esta zona");
        }
        if (SoldierActiveInScene.instancia.soldiersStatus[actualStatus.iD].imDead)
        {
            vidaSoldado.vida = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnDestroy()
    {
        SaveStatusScene();
    }
    void SaveStatusScene()
    {
        //Para almacenar una unica vez la escena en la que has muerto, se requerira saber si ya has muerto previamente,
        //Hasta que no hayas muerte y el soldado haya sido destruido al cambiar de escena imDead no contara como verdadero;
        //Tras pasar de escena si te lo establecera como muerto y no podrás volver almacenar la ubicación, porque solo puedes morir en una zona no en varias
        //NOTA: no se puede colocar imDead en el ActualStatus, porque lo ejecuta antes que ConservarMuertos haciendo que no almacene la escena en la que muere
        if (vidaSoldado.vida <= 0 && !SoldierActiveInScene.instancia.soldiersStatus[actualStatus.iD].imDead)
        {
            SoldierActiveInScene.instancia.soldiersStatus[actualStatus.iD].deathScene = SceneManager.GetActiveScene().buildIndex;
            SoldierActiveInScene.instancia.soldiersStatus[actualStatus.iD].imDead = true;
            Debug.Log("Scena muerte " + SceneManager.GetActiveScene().buildIndex);
        }
    }

}
