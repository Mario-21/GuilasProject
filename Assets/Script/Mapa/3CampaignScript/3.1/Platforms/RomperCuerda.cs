using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class RomperCuerda : MonoBehaviour
{
    public int indexMod;
    SpriteRenderer cuerda;
    BoxCollider2D boxCollider2D;
    [SerializeField]Rigidbody2D rbChild;
    [Header("Sprite Cuerda Rota")]
    [SerializeField] Sprite cuerdaRota;
    [Header("Sonido Cuerda")]
    public EventReference soundCuerdaRota;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        cuerda = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            cuerda.sprite = cuerdaRota;
            boxCollider2D.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer") || collision.gameObject.CompareTag("B8")) 
        {
            cuerda.sprite = cuerdaRota;
            rbChild.bodyType = RigidbodyType2D.Dynamic;
            boxCollider2D.enabled = false;
            AudioManager.instancia.PlayOneShot(soundCuerdaRota);
        }
    }
}
