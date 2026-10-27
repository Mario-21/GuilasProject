using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcaTriggerEnable : MonoBehaviour
{
    //NOTA: Esto se hace debido a que el trigger de la Cloaca lo puedes usar mientras caes o saltas, cosa que no quieres hacer porque te rompe el puzle
    [SerializeField] GameObject barca;
    [SerializeField] GameObject triggerTapaCloaca;
    void Update()
    {
        TriggerCloaca_Act_DesAct();
    }
    void TriggerCloaca_Act_DesAct()
    {
        //Si la barca NO EXISTE, no puedes usar el trigger de la tapa
        if (barca.activeInHierarchy)
        {
            Debug.Log("La barca existe");
            triggerTapaCloaca.SetActive(true);
            
        }
        //Si EXISTE, haz que se pueda usar el trigger de la tapa
        else if (!barca.activeInHierarchy)
        {
            Debug.Log("La barca son los padres");
            triggerTapaCloaca.SetActive(false);
        }
    }
}
