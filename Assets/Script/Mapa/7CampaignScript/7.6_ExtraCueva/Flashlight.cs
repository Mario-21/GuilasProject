using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Header("Flashlight Info")]
    [SerializeField] GameObject lightEffect;
    [SerializeField] PutGasMask putItem;
    [SerializeField] bool oscuridad;
    [Header("Animacion Mechero")]
    [SerializeField] Animator mecheroAnim;
    [SerializeField] Animator iluminacionAnim;



    bool onLight;
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
                    if (oscuridad)
                    {
                        iluminacionAnim.SetBool("Oscuridad", true);
                    }
                    else
                    {
                        iluminacionAnim.SetBool("Oscuridad", false);
                    }
                    
                }
                else
                {
                    mecheroAnim.enabled = false;
                }
                
            }
        }
    }
    void On_Off()
    {
        if (onLight)
        {
            lightEffect.SetActive(true);
        }
        else
        {
            lightEffect.SetActive(false);
        }
    }
}
