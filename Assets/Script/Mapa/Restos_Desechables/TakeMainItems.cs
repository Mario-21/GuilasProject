using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TakeMainItems : MonoBehaviour
{
    PlayerHere player;
    public int indexItemMision;
    [SerializeField] EventReference sfxMainItem;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (ListMissions.instanceMissions.missionsLevel[indexItemMision].success)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TakeItemMision();
    }
    void TakeItemMision()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Take"))
            {
                AudioManager.instancia.PlayOneShot(sfxMainItem);
                this.gameObject.SetActive(false);
                ListMissions.instanceMissions.missionsLevel[indexItemMision].success = true;
            }
        }
    }
}
