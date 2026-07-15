using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Photo : MonoBehaviour
{
    [Header("Información de la Misión")]
    public MainMission infoMission;
    [Header("Información UI Picture")]
    [SerializeField] GameObject iconPicture;
    [SerializeField] Animator picture;
    [SerializeField] EventReference takePicture;
    //Datos colisiones
    BoxCollider2D colliderPicture;
    bool iconControlador;
    PlayerHere player;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        colliderPicture = GetComponent<BoxCollider2D>();

        if (ListMissions.instanceMissions.missionsLevel[infoMission.indexListMissions].success)
        {
            //Desactiva para que no puedas volver a tomar la foto
            colliderPicture.enabled = false;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TakePicture();
    }
    void TakePicture()
    {
        if (player.playerImHere)
        {
            //Esto implica que si hay dos misiones en un mismo área el icono nunca aparecerá
            //En principio esto arreglaría el problema de tener varias misiones en una misma zona
            //dado que esto te permite hacer que el icono solo aparezca una vez y no se llame constantemente
            if (iconControlador)
            {
                iconPicture.SetActive(true);
                iconControlador = false;
            }

            if (Input.GetButtonDown("Action"))
            {
                //Animacion tomar Photo
                AudioManager.instancia.PlayOneShot(takePicture);
                picture.SetBool("Picture", true);

                //Establece la misión como completadas
                ListMissions.instanceMissions.numMissionsSuccess++;
                ListMissions.instanceMissions.missionsLevel[infoMission.indexListMissions].success = true;
                if (GameDataNoDestroy.instance.gameData.missionsComplete.ContainsKey(infoMission.idMission))
                {
                    GameDataNoDestroy.instance.gameData.missionsComplete.Remove(infoMission.idMission);

                }
                GameDataNoDestroy.instance.gameData.missionsComplete.Add(infoMission.idMission, ListMissions.instanceMissions.missionsLevel[infoMission.indexListMissions].success);

                //Desactiva todo
                colliderPicture.enabled = false;
                iconPicture.SetActive(false);
                this.enabled = false;
            }
        }
        else
        {
            if (!iconControlador)
            {
                iconPicture.SetActive(false);
                iconControlador = true;
            }
        }
    }
}
