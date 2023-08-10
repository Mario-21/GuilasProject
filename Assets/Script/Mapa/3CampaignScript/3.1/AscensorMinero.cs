using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AscensorMinero : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocidad;
    public Transform[] posiciones;

    public bool movimiento;
    public int piso;
    int pisoActual;

    StudioEventEmitter ascensorEmissor;
    int reproduce;
    void Start()
    {
        ascensorEmissor = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.ascensorMove, this.gameObject);
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Ascendor();
        MovimientoDetectorAscensor();
    }
    void Ascendor()
    {
        Vector3 movePosition = transform.position;
        movePosition.y = Mathf.MoveTowards(transform.position.y, posiciones[piso].position.y, velocidad * Time.fixedDeltaTime);
        rb.MovePosition(movePosition);
    }
    void MovimientoDetectorAscensor()
    {
        if(transform.position != posiciones[piso].position)
        {
            movimiento = true;
            //Reproducir una vez hasta que no llegue a su destino no se restea
            if (reproduce < 1)
            {
                ascensorEmissor.Play();
                reproduce++;
            }
        }
        else
        {
            movimiento = false;
            pisoActual = piso;
            reproduce = 0;
            ascensorEmissor.Stop();
        }
    }
    void SoundAscensor()
    {
        if (movimiento)
        {
            if (reproduce < 1)
            {
                ascensorEmissor.Play();
                reproduce++;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Esto es el sticker, quiza cambiar 
        if (collision.gameObject.CompareTag("Player")) { Debug.Log("Player ha subido al ascensor"); collision.gameObject.transform.parent = transform; };
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { Debug.Log("Player ha subido al ascensor"); collision.gameObject.transform.parent = null; }
    }
}
