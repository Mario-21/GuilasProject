using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Caer_Cabeza : MonoBehaviour
{
    public int indexModificar;
    Rigidbody2D rb;
    public enum TypePlatform
    {
        rama,
        polipasto
    }
    [Header("Tipo de plataforma")]
    public TypePlatform typePlatform;

    [Header("Item a caer")]
    public Caida_Objeto caidaObjeto;

    [Header("Trigger Daño Player")]
    public GameObject triggerDamagePlayer;

    [Header("Saltos para hacer qur caiga")]
    public int limitevecesSaltadas = 3;
    int vecesSaltadas;

    [Header("Sound Effect Ramas")]
    public EventReference shoot_Caer;
    public EventReference player_Touch;
    public EventReference impacto;

    bool golpePorBala;
    int sonidoGolpeBala;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CaerPlataforma();
    }
    void CaerPlataforma()
    {
        switch (typePlatform)
        {
            //Si es la rama puedes simplemente disparar a la misma para que esta caiga
            case TypePlatform.rama:
                if (golpePorBala)
                {
                    triggerDamagePlayer.SetActive(true);
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    rb.gravityScale = 1;
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexModificar].modificacion = true;
                    if (sonidoGolpeBala < 1)
                    {
                        AudioManager.instancia.PlayOneShot(shoot_Caer);
                        sonidoGolpeBala++;
                    }
                }
                break;
            //El polipasto es dependiente de una cuerda por tanto solo puede caer al romper la misma
            case TypePlatform.polipasto:
                //Polipasto requiere de una cuerda para que sea activado, cuando la bala entra en contacto con la cuerda la variable se enciendo
                //Encenderse significa que el objeto debe estar cayendo lo que hace que se active el trigger de daño para el jugador
                if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModificar].modificacion)
                {
                    Debug.Log("Activado El TriggerDamagePlayer");
                    triggerDamagePlayer.SetActive(true);
                }
                break;
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            golpePorBala = true;
            Destroy(collision.gameObject);
            //AudioManager.instancia.PlayOneShot(shoot_Caer);
        }
        /*

            switch (typePlatform)
        {
            //Si es la rama puedes simplemente disparar a la misma para que esta caiga
            case TypePlatform.rama:
                if (collision.gameObject.CompareTag("BalaPlayer"))
                {
                    triggerDamagePlayer.SetActive(true);
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    rb.gravityScale = 1;
                    Destroy(collision.gameObject);
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexModificar].modificacion = true;
                    AudioManager.instancia.PlayOneShot(shoot_Caer);
                }
                break;
            //El polipasto es dependiente de una cuerda por tanto solo puede caer al romper la misma
            case TypePlatform.polipasto:
                //Polipasto requiere de una cuerda para que sea activado, cuando la bala entra en contacto con la cuerda la variable se enciendo
                //Encenderse significa que el objeto debe estar cayendo lo que hace que se active el trigger de daño para el jugador
                if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModificar].modificacion)
                {
                    Debug.Log("Activado El TriggerDamagePlayer");
                    triggerDamagePlayer.SetActive(true);
                }
                break;
                
        }
        */
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Esto es irrelevante para el tipo de plataforma
        if (collision.gameObject.CompareTag("Player"))
        {
            vecesSaltadas++;
            AudioManager.instancia.PlayOneShot(player_Touch);
            if (vecesSaltadas >= limitevecesSaltadas)
            {
                triggerDamagePlayer.SetActive(true);
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 1;
                AudioManager.instancia.PlayOneShot(shoot_Caer);
            }
        }
        if (collision.gameObject.layer == 9 || collision.gameObject.CompareTag("Enemy"))
        {
            AudioManager.instancia.PlayOneShot(impacto);
            //Cuando choca contra el suelo tambien deberia modificarse
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModificar].modificacion = true;
            caidaObjeto.ObjetoInGround();
        }
        if (collision.gameObject.CompareTag("B8"))
        {
            golpePorBala = true;
        }
    }
}
