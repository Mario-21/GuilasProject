using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWaterPosion : MonoBehaviour
{
    [SerializeField] VidaPlayer playerVida;

    [Header("ColdownDaño")]
    public float coldownDamageLimit;
    public float coldownDamage;
    [Header("Daño Agua")]
    public float damagePoison;

    public int countDaño;
    bool dañoPoison;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetPoisonDamage();
        if (dañoPoison) DamagePoison();
        else
        {
            countDaño = 0;
            coldownDamage = 0;
        }
    }
    void DamagePoison()
    {
        if(countDaño < 1)
        {
            playerVida.Daño(damagePoison);
            Debug.Log("Daño recibido por veneno");
            countDaño++;
        }
    }
    void ResetPoisonDamage()
    {
        if(countDaño >= 1)
        {
            coldownDamage += Time.deltaTime;
            if (coldownDamage >= coldownDamageLimit)
            {
                countDaño = 0;
                coldownDamage = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dañoPoison = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dañoPoison = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dañoPoison = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dañoPoison = false;
        }
    }
    private void OnDisable()
    {
        //Esto se hace para no recibir daño al colocarte en el agua
        dañoPoison = false;
        countDaño = 1;

    }
}
