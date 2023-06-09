using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerWeapon : MonoBehaviour
{
    PlayerHere player;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        if (SpecialWeapons.specialW.b8) this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.playerImHere) PickWeapon();
    }
    void PickWeapon()
    {
        if (Input.GetButtonDown("Take"))
        {
            SpecialWeapons.specialW.b8 = true;
            this.gameObject.SetActive(false);
        }
    }
}
