using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWaterPosion : MonoBehaviour
{
    [SerializeField] VidaPlayer playerVida;

    [Header("ColdownDaño")]
    public float coldownDamageLimit;
    float coldownDamage;
    [Header("Daño Agua")]
    public float damagePoison;

    int countDaño;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetPoisonDamage();
    }
    void DamagePoison()
    {
        if(countDaño < 1)
        {
            playerVida.Daño(damagePoison);
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
            DamagePoison();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DamagePoison();
        }
    }
}
