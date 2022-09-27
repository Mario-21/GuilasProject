using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffDetectarDoctor : MonoBehaviour
{
    [Header("Detector Info")]
    [SerializeField] BoxCollider2D colliderDetector;
    [SerializeField] bool offDetector;
    [Header("Doctor Info")]
    [SerializeField] SoldadoNormal doctor;
    [SerializeField] SoldierLife doctorLife;
    
    void Start()
    {
        if(doctorLife.vida > 0)
        {
            offDetector = true;
        }
        else if(doctorLife.vida <= 0)
        {
            offDetector = false;
        }
        
    }
    void Update()
    {
        if (!doctor.berserker && doctorLife.vida > 0) On_Off_Detector();
    }
    void On_Off_Detector()
    {
        if (!offDetector)
        {
            colliderDetector.enabled = false;
        }
        else
        {
            colliderDetector.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            offDetector = !offDetector;
        }
    }
}
