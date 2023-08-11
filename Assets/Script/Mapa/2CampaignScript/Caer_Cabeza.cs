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
    [SerializeField] Caida_Objeto caidaObjeto;

    [Header("Saltos para hacer qur caiga")]
    public int LimitevecesSaltadas = 3;
    int vecesSaltadas;

    [Header("Sound Effect Ramas")]
    public EventReference shoot_Caer;
    public EventReference player_Touch;
    public EventReference impacto;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (typePlatform)
        {
            //Si es la rama puedes simplemente disparar a la misma para que esta caiga
            case TypePlatform.rama:
                if (collision.gameObject.CompareTag("BalaPlayer"))
                {
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    rb.gravityScale = 1;
                    Destroy(collision.gameObject);
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexModificar].modificacion = true;
                    AudioManager.instancia.PlayOneShot(shoot_Caer);
                }
                break;
            //El polipasto es dependiente de una cuerda por tanto solo puede caer al romper la misma
            case TypePlatform.polipasto:
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Esto es irrelevante para el tipo de plataforma
        if (collision.gameObject.CompareTag("Player"))
        {
            vecesSaltadas++;
            AudioManager.instancia.PlayOneShot(player_Touch);
            if (vecesSaltadas >= LimitevecesSaltadas)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 1;
                AudioManager.instancia.PlayOneShot(shoot_Caer);
            }
            else
            {
                //AudioManager.instancia.PlayOneShot(player_Touch);
            }
        }
        if (collision.gameObject.layer == 9 || collision.gameObject.CompareTag("Enemy"))
        {
            AudioManager.instancia.PlayOneShot(impacto);
            //Cuando choca contra el suelo tambien deberia modificarse
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModificar].modificacion = true;
            caidaObjeto.ObjetoInGround();
            //Quiza cambiar 
            Destroy(this.gameObject);
        }
    }
}
