using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkinPlayer : MonoBehaviour
{
    [Header("Informacion del Tag")]
    [SerializeField] SaveButton mascaraButton;
    public string tagName = "Mascara";
    bool canPut;
    public bool putSkin;
    [Header("Informacion Skin")]
    public Animator skinPlayer;
    public RuntimeAnimatorController otherSkin;
    public RuntimeAnimatorController originalSkin;
    [Header("Brazo Jugador")]
    public bool cambiarBrazo;
    [SerializeField] SpriteRenderer brazoPlayer;
    [SerializeField] Sprite brazoBasePlayer;

    // Update is called once per frame
    void Update()
    {
        CanUseMask();
        OffMask();
    }
    void CanUseMask()
    {
        if (canPut)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.takeClothes);
                putSkin = true;
                PutMask();
            }
        }
    }
    void PutMask()
    {
        if (putSkin)
        {
            skinPlayer.runtimeAnimatorController = otherSkin;
            mascaraButton.UsosGastados();
        }
    }
    void OffMask()
    {
        //NOTA: En el casco minero del nivel 5 te va habilitar ambos botones
        //Si llevo el cosmetico
        if (putSkin)
        {
            //Pulso la te para quitarmelo
            if (Input.GetButtonDown("Take_Off"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.takeOffClothes);
                skinPlayer.runtimeAnimatorController = originalSkin;
                mascaraButton.HabilitarUsos();
                putSkin = false;
                if (cambiarBrazo) brazoPlayer.sprite = brazoBasePlayer;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName)) canPut = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName)) canPut = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName)) canPut = false;
    }
}
