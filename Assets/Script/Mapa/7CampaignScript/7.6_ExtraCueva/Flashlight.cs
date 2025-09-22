using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Header("Flashlight Info")]
    [SerializeField] SpriteRenderer mecheroSprite;
    [SerializeField] Sprite mecheroDefault;
    [SerializeField] GameObject lightEffect;
    [SerializeField] PutGasMask putItem;
    [SerializeField] bool oscuridad;
    [Header("Animacion Mechero")]
    [SerializeField] Animator mecheroAnim;
    [SerializeField] Animator iluminacionAnim;



    bool onLight;
    private void Start()
    {
    }
    void Update()
    {
        ActiveLight();
        On_Off();
    }
    void ActiveLight()
    {
        if (putItem.putMask)
        {
            if (Input.GetButtonDown("UseMask"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.lighterFire);
                onLight = !onLight;
                if (onLight)
                {
                    mecheroAnim.enabled = true;
                }
                else
                {
                    mecheroAnim.enabled = false;
                    mecheroSprite.sprite = mecheroDefault;
                }
                
            }
        }
        // No creo que funcione ya que cuando me lo quito se desactiva el objeto y por ende no se va a ejecutar
    }
    void On_Off()
    {
        if (onLight)
        {
            lightEffect.SetActive(true);
            if (oscuridad)
            {
                Debug.Log("Variable oscuridad Activa");
                iluminacionAnim.SetBool("Dark", true);
            }
            else
            {
                Debug.Log("Variable oscuridad Apagada");
                iluminacionAnim.SetBool("Dark", false);
            }
        }
        else
        {
            lightEffect.SetActive(false);
        }
    }
    private void OnEnable()
    {
        //Cambiar tambien el sprite del mechero al default
        mecheroAnim.enabled = false;
        onLight = false;
        mecheroSprite.sprite = mecheroDefault;
        lightEffect.SetActive(false);
    }
}
