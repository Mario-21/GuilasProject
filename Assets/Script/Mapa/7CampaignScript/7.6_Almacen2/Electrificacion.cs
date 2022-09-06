using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrificacion : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] VidaPlayer playerVida;
    [SerializeField] BloquearMovimientoPlayer playerBlock;
    [Header("Atributes Empuje")]
    public float timeOnPlayerLimit;
    public float timeOnPlayer;
    bool enabledMov;

    float repeatDamage;
    public bool canRepeat;

    void Update()
    {
        //Creo que no voy a añadir fuerzas, pondré unos efectos con partículas uno animación de electrocución y ya
        Electricity();
        RepeatDamage();
    }
    void Electricity()
    {
        if (enabledMov)
        {
            timeOnPlayer += Time.deltaTime;
            if (timeOnPlayer >= timeOnPlayerLimit)
            {
                playerBlock.HabilitarMovPlayer();
                timeOnPlayer = 0;
                enabledMov = false;
            }
        }
    }
    void RepeatDamage()
    {
        if (canRepeat)
        {
            repeatDamage += Time.deltaTime;
            if (repeatDamage >= timeOnPlayerLimit + 0.1)
            {
                playerVida.Daño(20);
                //No inhabilitar llamar al bloqueoPlayer
                playerBlock.BloquearMovPlayer();
                enabledMov = true;
                repeatDamage = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            playerVida.Daño(20);
            Debug.Log("Capela");
            playerBlock.BloquearMovPlayer();
            enabledMov = true;
            canRepeat = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canRepeat = false;
            playerBlock.HabilitarMovPlayer();
            repeatDamage = 0;
        }
    }
}
