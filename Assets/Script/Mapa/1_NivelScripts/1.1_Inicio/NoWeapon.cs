using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWeapon : MonoBehaviour
{
    public int indexNoWeapon;

    [Header("Weapons Data")]
    [SerializeField] ArmaController pistol;
    SpriteRenderer pistolSprite;
    SpriteRenderer pistolCinturaSprite;
    [SerializeField] ChangeWeapon changeWeapon;
    [SerializeField] B8Arma b8;
    SpriteRenderer b8Sprite;
    SpriteRenderer b8CinturaSprite;
    [Header("Mochila Data")]
    [SerializeField] SpriteRenderer mochilaSprite;
    [SerializeField] SpriteRenderer correaMochilaSprite;
    private void Awake()
    {
        //Sprite Pistola
        pistolSprite = pistol.GetComponent<SpriteRenderer>();
        pistolCinturaSprite = pistol.pistolaCintura.GetComponent<SpriteRenderer>();
        //Sprite B8
        //Si tienes el b8
        b8Sprite = b8.GetComponent<SpriteRenderer>();
        b8CinturaSprite = b8.bCatCintura.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexNoWeapon].modificacion)
        {
            pistol.enabled = true;
            pistolSprite.enabled = true;
            pistolCinturaSprite.enabled = true;
            changeWeapon.enabled = true;
            if (SpecialWeapons.specialW.b8) 
            {
                b8.enabled = true;
                b8Sprite.enabled = true;
                b8CinturaSprite.enabled = true;
            }
            //Coloca la mochila
            mochilaSprite.enabled = true;
            correaMochilaSprite.enabled = true;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexNoWeapon].modificacion)
        {
            pistol.enabled = true;
            pistolSprite.enabled = true;
            pistolCinturaSprite.enabled = true;
            changeWeapon.enabled = true;
            if (SpecialWeapons.specialW.b8)
            {
                b8.enabled = true;
                b8Sprite.enabled = true;
                b8CinturaSprite.enabled = true;
            }
            //Coloca la mochila
            mochilaSprite.enabled = true;
            correaMochilaSprite.enabled = true;
            this.enabled = false;
        }
        else
        {
            pistol.enabled = false;
            pistolSprite.enabled = false;
            pistolCinturaSprite.enabled = false;
            changeWeapon.enabled = false;
            if (SpecialWeapons.specialW.b8)
            {
                b8.enabled = false;
                b8Sprite.enabled = false;
                b8CinturaSprite.enabled = false;
            }
            mochilaSprite.enabled = false;
            correaMochilaSprite.enabled = false;

            Debug.Log("No tengo arma");
        }
    }
}
