using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerWeapon : MonoBehaviour
{
    public int indexMod;
    PlayerHere player;
    [SerializeField] SpriteRenderer bCatCintura;
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
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.b8Recoger);
            SpecialWeapons.specialW.b8 = true;
            bCatCintura.enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
