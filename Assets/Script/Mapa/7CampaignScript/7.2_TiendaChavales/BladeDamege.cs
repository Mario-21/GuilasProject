using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeDamege : MonoBehaviour
{
    [Header("Player Properties")]
    [SerializeField] VidaPlayer playerLife;
    [SerializeField] Rigidbody2D playerRb2D;
    [SerializeField] JugadorMovimiento bloqPlayer;
    [Header ("Atributes Empuje")]
    public float fuerzaEmpuje;
    public float timeLimiteOnPlayer;
    float timeOnPlayer;
    bool enabledMov;

    private void Update()
    {
        if (enabledMov)
        {
            timeOnPlayer += Time.deltaTime;
            if(timeOnPlayer >= timeLimiteOnPlayer)
            {
                bloqPlayer.enabled = true;
                timeOnPlayer = 0;
                enabledMov = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerLife.Daño(15f);
            playerRb2D.AddForce(Vector2.right * fuerzaEmpuje, ForceMode2D.Impulse);
            bloqPlayer.enabled = false;
            enabledMov = true;
        }
    }
}
