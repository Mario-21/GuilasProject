using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionarTrampas : MonoBehaviour
{
    public int indexModTrampasOn;

    public Transform baldosaBaja;
    public float speed;

    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModTrampasOn].modificacion)
        {
            transform.position = baldosaBaja.position;
            this.enabled = false;
        }
    }
    private void Update()
    {
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexModTrampasOn].modificacion)
        {
            transform.position = Vector2.MoveTowards(transform.position, baldosaBaja.position, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            //Añadir sonido baldosa bajando
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModTrampasOn].modificacion = true;
            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.baldosaTrap);
            
        } 
    }
}
