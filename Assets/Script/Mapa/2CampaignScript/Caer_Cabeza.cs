using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caer_Cabeza : MonoBehaviour
{
    Rigidbody2D rb;

    public int indexModificar;

    [SerializeField] Caida_Objeto caidaObjeto;
    [SerializeField] JugadorMovimiento playerAltura;

    int vecesSaltadas;
    public int LimitevecesSaltadas = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1;
            Destroy(collision.gameObject);
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModificar].modificacion = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vecesSaltadas++;
            if(vecesSaltadas >= LimitevecesSaltadas)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 1;
            }
        }
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        {
            //Cuando choca contra el suelo tambien deberia modificarse
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModificar].modificacion = true;
            caidaObjeto.ObjetoInGround();
            //Quiza cambiar 
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //O lo quito y simplemente lo mantengo con darle 3 veces encima o colocas el FallDamage, lo que con lleva que tenga que reasignarlo en todos los niveles :(
            /*
            if (Mathf.Abs(playerAltura.diferenciaAltura) > 5)
            {
                Debug.Log("FD");
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 1;
                rb.AddForce(new Vector2(0f, -1f),ForceMode2D.Impulse);
            }*/
        }
    }
}
