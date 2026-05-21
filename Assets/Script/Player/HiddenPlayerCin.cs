using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class HiddenPlayerCin : MonoBehaviour
{
    [Header("Cuerpo Player")]
    public GameObject cuerpoPlayerCin;
    public List<SpriteRenderer> listaCuerpo;

    //Informacion del escondite y estado del player
    [HideInInspector] public bool ocultoPlayerCin;
    [HideInInspector]public GameObject particlesHidden;
    [HideInInspector]public EventReference hiddenSound;

    [Header("Layers")]
    public int ocultar;
    public int visible;

    [Header("Iconos Player")]
    public Sprite iconoOcultar;
    public GameObject iconoZone;
    SpriteRenderer iconoZoneSprite;
    void Start()
    {
        iconoZoneSprite = iconoZone.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ocultoPlayerCin)
        {
            CuerpoOcultarCin();
        }
        else
        {
            CuerpoReaparecerCin();
        }
    }
    void CuerpoOcultarCin()
    {
        foreach (SpriteRenderer spriteBody in listaCuerpo)
        {
            spriteBody.enabled = false;
        }
        cuerpoPlayerCin.layer = ocultar;
        cuerpoPlayerCin.tag = "Escondite";
        //Que el icono desaparezca al yo cambiar el bool en la cinematica
        //iconoZone.SetActive(false);

    }
    void CuerpoReaparecerCin()
    {
        foreach (SpriteRenderer spriteBody in listaCuerpo)
        {
            spriteBody.enabled = true;
        }
        cuerpoPlayerCin.layer = visible;
        cuerpoPlayerCin.tag = "Player";
        //iconoZone.SetActive(true);
    }
    public void SonidoYParticulaEsconderseCin() 
    {
        Instantiate(particlesHidden, cuerpoPlayerCin.transform.position, Quaternion.identity);
        AudioManager.instancia.PlayOneShot(hiddenSound);
        iconoZone.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Escondite")
        {
            //Aparece el icono, si no estoy escondido
            iconoZone.SetActive(true);
            iconoZoneSprite.sprite = iconoOcultar;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Escondite")
        {
            iconoZone.SetActive(false);

        }
    }


}
