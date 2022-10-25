using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconItem : MonoBehaviour
{
    [SerializeField] GameObject iconoZone;
    [SerializeField] SpriteRenderer iconeZoneSprite;
    [SerializeField] Sprite icon;

    bool iconSee;
    void Update()
    {
        //cuando realizas la acción se sigue viendo el icono, no se si hacer que se quite o simplemente dejarlo
        if (iconSee)
        {
            iconeZoneSprite.sprite = icon;
            iconoZone.SetActive(true);
            //Seria añadirle un bool, que al presionar el boton de acción lo cambiara.
            //Mostrando o no el icono, además de colocar que el IconSee + !new Bool, para ver el icono
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            iconSee = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            iconSee = false;
            iconoZone.SetActive(false);
        }
    }
}
