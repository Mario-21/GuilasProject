using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmOn : MonoBehaviour
{
    bool playerAlarm;
    [SerializeField] Animator alarma;
    void Update()
    {
        Alarm();
    }
    void Alarm()
    {
        if (playerAlarm)
        {
            alarma.SetBool("Alarm", true);
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
