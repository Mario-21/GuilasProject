using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Photo : MonoBehaviour
{
    public int indexMainMission;
    PlayerHere player;
    [SerializeField] Animator picture;
    [SerializeField] EventReference takePicture;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if(ListMissions.listaMissions.missionsMap[indexMainMission].success) Destroy(this.gameObject);
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
            if (Input.GetButtonDown("Action"))
            {
                //Animacion tomar Photo
                AudioManager.instancia.PlayOneShot(takePicture);
                picture.SetBool("Picture", true);
                ListMissions.listaMissions.missionsMap[indexMainMission].success = true;
                Destroy(this.gameObject);
            }
        }
    }
}
