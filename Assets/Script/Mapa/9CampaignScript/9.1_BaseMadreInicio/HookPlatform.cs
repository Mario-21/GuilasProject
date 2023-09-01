using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class HookPlatform : MonoBehaviour
{
    [Header("Datos de la Plataforma")]
    public float velocidad;
    SpriteRenderer hookSprite;
    BoxCollider2D hookCollider;
    [SerializeField] BoxCollider2D stickyCollider;
    [Header("Caja Gancho")]
    [SerializeField] SpriteRenderer caja;
    [SerializeField] BoxCollider2D cajaGancho;
    public bool tengoCaja;
    [Header("Ubicaciones del Hook")]
    public Transform[] ubicaciones;
    int indexUbi;
    [Header("Tiempo permanecer ubicaciones")]
    public float timeInUbiLimit;
    float timeInUbi;
    [Header("Sound Hook")]
    StudioEventEmitter emitterHook;
    [SerializeField] EventReference moveHookSound;

    int sfxHook;
    void Start()
    {
        emitterHook = AudioManager.instancia.InitializeEventEmitter(moveHookSound, this.gameObject);
        hookCollider = GetComponent<BoxCollider2D>();
        hookSprite = GetComponent<SpriteRenderer>();
        transform.position = ubicaciones[0].position;
    }
    void Update()
    {
        HookMove();
        HookBack();
        HookAppear();
    }
    void HookMove()
    {
        //Se dirige a las ubicaciones
        transform.position = Vector2.MoveTowards(transform.position, ubicaciones[indexUbi].position, velocidad * Time.deltaTime);

        if(Vector2.Distance(ubicaciones[indexUbi].position,transform.position) < 0.5f)
        {
            timeInUbi += Time.deltaTime;
            emitterHook.Stop();
            if(timeInUbi >= timeInUbiLimit)
            {
                indexUbi++;
                timeInUbi = 0;
                sfxHook = 0;
            }
        }
        else
        {
            if(sfxHook < 1)
            {
                emitterHook.Play();
                sfxHook++;
            }
        }
    }
    void HookBack()
    {
        if(indexUbi >= ubicaciones.Length)
        {
            //Desaparecer el gancho
            hookSprite.enabled = false;
            hookCollider.enabled = false;
            //Desaparecer el Sticky
            stickyCollider.enabled = false;
            //El gancho vuelve a la ubicación original
            indexUbi = 0;
            transform.position = ubicaciones[0].position;

        }
    }
    void HookAppear()
    {
        if(indexUbi <= 0)
        {
            //Al estar de nuevo en la zona inicial el gancho vuelve a aparecer
            hookSprite.enabled = true;
            hookCollider.enabled = true;
            stickyCollider.enabled = true;
            //Dependiendo de la elección tendrás una caja o no
            BoxHook();
        }
    }
    void BoxHook()
    {
        if (tengoCaja)
        {
            caja.enabled = true;
            cajaGancho.enabled = true;
        }
        else
        {
            caja.enabled = false;
            cajaGancho.enabled = false;
        }
    }
}
