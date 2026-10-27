using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffDetectarDoctor : MonoBehaviour
{
    [Header("Detector Info")]
    [SerializeField] BoxCollider2D colliderDetector;
    [SerializeField] SpriteRenderer spriteDetector;
    [SerializeField] SpriteRenderer spriteDetectorInside;
    public bool offDetector;
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
            spriteDetector.enabled = false;
            spriteDetectorInside.enabled = true;
        }
        else
        {
            colliderDetector.enabled = true;
            spriteDetector.enabled = true;
            spriteDetectorInside.enabled = false;
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
