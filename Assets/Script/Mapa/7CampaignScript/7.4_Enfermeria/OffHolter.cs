using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class OffHolter : MonoBehaviour
{
    PlayerHere player;
    [Header("Holter Info")]
    public GameObject holterEffect;
    [SerializeField] SpriteRenderer botonHolter;
    public bool onHolter;

    [Header("Doctor Info")]
    [SerializeField] SoldadoNormal doctor;
    [SerializeField] Transform doctorOriginalPos;
    public bool enemyHere;
    public float timeOnHolterDoctor;

    StudioEventEmitter emitterHolter;
    int onceAudio;
    private void Start()
    {
        emitterHolter = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.holter, this.gameObject);
        player = GetComponent<PlayerHere>();
    }
    void Update()
    {
        if (player.playerImHere) ActiveHolter();
        OnHolter();
        OnHolterSoldier();
    }
    void ActiveHolter()
    {
        if (Input.GetButtonDown("Action"))
        {
            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
            onHolter = !onHolter;
        }
    }
    void OnHolter()
    {
        if (onHolter)
        {
            holterEffect.SetActive(true);
            botonHolter.color = Color.green;
            if (onceAudio < 1)
            {
                emitterHolter.Play();
                onceAudio++;
            }
        }
        else
        {
            holterEffect.SetActive(false);
            botonHolter.color = Color.red;
            onceAudio = 0;
            emitterHolter.Stop();
        }
    }
    void OnHolterSoldier()
    {
        if (!onHolter && enemyHere)
        {
            timeOnHolterDoctor += Time.deltaTime;
            if(timeOnHolterDoctor >= 4)
            {
                timeOnHolterDoctor = 0;
                onHolter = true;
                doctor.ubicacionesDirigir[0] = doctorOriginalPos;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) enemyHere = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) enemyHere = false;
    }
}
