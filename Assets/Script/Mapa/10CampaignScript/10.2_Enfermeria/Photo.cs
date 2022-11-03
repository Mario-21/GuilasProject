using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo : MonoBehaviour
{
    public int indexMainMission;
    PlayerHere player;
    [SerializeField] Animator picture;
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
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //Animacion tomar Photo
                picture.SetBool("Picture", true);
                ListMissions.listaMissions.missionsMap[indexMainMission].success = true;
                Destroy(this.gameObject);
            }
        }
    }
}
