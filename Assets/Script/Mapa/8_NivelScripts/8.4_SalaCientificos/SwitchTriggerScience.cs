using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTriggerScience : MonoBehaviour
{
    [SerializeField] PutGasMask maskPlayer;
    [Header("Rangos Detectores Enemigos")]
    [SerializeField] List<Detectar_y_Echar> triggerDetectores;
    [Header("Rangos Cono Enemigos")]
    [SerializeField] List<GameObject> rangeVisionCono;
    [Header("Enemigos")]
    [SerializeField] List<SoldierLife> cientificos;

    int cientificosOnTriggers;
    int cientificosOffTriggers;

    // Update is called once per frame
    void Update()
    {
        SwitchRangeVision();
    }
    void SwitchRangeVision()
    {
        if (maskPlayer.putMask)
        {
            cientificosOffTriggers = 0;
            //Solo quiero que lo ejecute una vez el bucle, para no estar constantemente recorriendo lo
            if(cientificosOnTriggers < triggerDetectores.Count)
            {
                for(int e = 0; e < triggerDetectores.Count; e++)
                {
                    //Comprobar si los cientificos estan vivos o no
                    if(cientificos[e].vida > 0)
                    {
                        //Si lo estan, intercambia sus rangos de vision
                        triggerDetectores[e].gameObject.SetActive(false);
                        rangeVisionCono[e].gameObject.SetActive(true);
                        cientificosOnTriggers++;
                    }
                    else if (cientificos[e].vida <= 0)
                    {
                        //sino lo estan, pasa y continua con el siguiente
                        cientificosOnTriggers++;
                    }
                }
            }
        }
        //Al quitarte la mascara reinicia el conteo, para volver a comprobarlo una vez te la vuelvas a colocar
        else
        {
            cientificosOnTriggers = 0;
            if (cientificosOffTriggers < triggerDetectores.Count)
            {
                for (int e = 0; e < triggerDetectores.Count; e++)
                {
                    //Comprobar si los cientificos estan vivos o no
                    if (cientificos[e].vida > 0)
                    {
                        //Si lo estan, intercambia sus rangos de vision
                        triggerDetectores[e].gameObject.SetActive(true);
                        rangeVisionCono[e].gameObject.SetActive(false);
                        cientificosOffTriggers++;
                    }
                    else if (cientificos[e].vida <= 0)
                    {
                        //sino lo estan, pasa y continua con el siguiente
                        cientificosOffTriggers++;
                    }
                }
            }
        }
    }
}
