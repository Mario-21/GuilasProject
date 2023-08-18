using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class OpenDoorInside : MonoBehaviour
{
    public int indexModificador;
    [SerializeField] SpriteRenderer door;
    [SerializeField] Sprite doorOpen;
    BoxCollider2D openCollider;

    [Header("Sound Effect Door")]
    [SerializeField] EventReference doorOpenSFX;
    private void Start()
    {
        openCollider = GetComponent<BoxCollider2D>();
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexModificador].modificacion) AbrirPuertaInside();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Nota: Si en el 4.3 te siguen en la zona de abajo tambien abriran las puertas
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy")) 
        {
            AbrirPuertaInside();
            AudioManager.instancia.PlayOneShot(doorOpenSFX);
        }
    }
    void AbrirPuertaInside()
    {
        door.sprite = doorOpen;
        //Coge el collider de la puerta cerrada
        door.GetComponent<BoxCollider2D>().enabled = false;
        openCollider.enabled = false;
        StatusGameobjectsVariables.statusGameobject.modificacion[indexModificador].modificacion = true;
    }
}
