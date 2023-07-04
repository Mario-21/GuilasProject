using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMainItems : MonoBehaviour
{
    PlayerHere player;
    public int indexItemMision;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (ListMissions.listaMissions.missionsMap[indexItemMision].success)
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
                this.gameObject.SetActive(false);
                ListMissions.listaMissions.missionsMap[indexItemMision].success = true;
            }
        }
    }
}
