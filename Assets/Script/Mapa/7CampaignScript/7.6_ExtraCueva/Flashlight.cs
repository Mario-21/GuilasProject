using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Header("Flashlight Info")]
    [SerializeField] GameObject lightEffect;
    [SerializeField] PutGasMask putItem;
    [Header("Color Player")]
    [SerializeField] Color oscuridad;
    [SerializeField] List<SpriteRenderer> playerSprites;


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
                    foreach (SpriteRenderer player in playerSprites)
                    {
                        player.color = Color.white;
                    }
                }
                else
                {
                    foreach (SpriteRenderer player in playerSprites)
                    {
                        player.color = oscuridad;
                    }
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
