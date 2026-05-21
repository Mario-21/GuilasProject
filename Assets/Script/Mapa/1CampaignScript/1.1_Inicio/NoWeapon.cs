using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWeapon : MonoBehaviour
{
    public int indexNoWeapon;

    [Header("Weapons Data")]
    [SerializeField] ArmaController pistol;
    SpriteRenderer pistolSprite;
    [SerializeField] ChangeWeapon changeWeapon;
    [SerializeField] B8Arma b8;
    SpriteRenderer b8Sprite;

    int once;
    private void Awake()
    {
        pistolSprite = pistol.GetComponent<SpriteRenderer>();
        b8Sprite = b8.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexNoWeapon].modificacion)
        {
            pistol.enabled = true;
            pistolSprite.enabled = true;
            changeWeapon.enabled = true;
            b8.enabled = true;
            b8Sprite.enabled = true;
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
            changeWeapon.enabled = true;
            b8.enabled = true;
            b8Sprite.enabled = true;
            this.enabled = false;
        }
        else
        {
            pistol.enabled = false;
            pistolSprite.enabled = false;
            changeWeapon.enabled = false;
            b8.enabled = false;
            b8Sprite.enabled = false;

            Debug.Log("No tengo arma");
        }
    }
}
