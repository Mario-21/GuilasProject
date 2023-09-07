using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AlarmOn : MonoBehaviour
{
    bool playerAlarm;
    [SerializeField] Animator alarma;

    int alarmSound;
    void Update()
    {
        Alarm();
    }
    void Alarm()
    {
        if (playerAlarm)
        {
            alarma.SetBool("Alarm", true);
            if(alarmSound < 1)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.alarm);
                alarmSound++;
            }
            //Sonido Alarma
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           playerAlarm = true;
        }
    }
}
