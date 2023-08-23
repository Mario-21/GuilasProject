using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class UseDrillScene : MonoBehaviour
{
    bool encenderScene;
    bool startEvento;
    PlayerHere player;
    public int indexMod;
    [SerializeField] Events evento;
    [Header("Drill Effect")]
    [SerializeField] ParticleSystem drillEffect;
    [SerializeField] GameObject fakeGround;
    [Header("Generator Data")]
    [SerializeField] SpriteRenderer buttonGenerator;
    [Header("Sound Effects Drill")]
    StudioEventEmitter emissorDrill;
    [SerializeField] GameObject drillItem;
    [SerializeField] EventReference drillSound;


    int drillEffectUse;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        emissorDrill = AudioManager.instancia.InitializeEventEmitter(drillSound, drillItem);

        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) DeleteGroundFake();
    }

    // Update is called once per frame
    void Update()
    {
        DigWithDrill();
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) ActiveDrill();
        ExecuteDigWithDrill();
    }
    void ActiveDrill()
    {
        if (player.playerImHere)
        {
            evento.actionOnCinematic += DeleteGroundFake;
            if (Input.GetButtonDown("Action"))
            {
                encenderScene = true;
                startEvento = true;

            }
        }
    }
    void ExecuteDigWithDrill()
    {
        if (startEvento) evento.Cinematic(ref startEvento);
    }
    void DigWithDrill()
    {
        if (encenderScene)
        {
            if(drillEffectUse < 1)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
                buttonGenerator.color = Color.green;
                drillEffect.Play();
                emissorDrill.Play();
                drillEffectUse++;
            }
        }
        else 
        {
            if(drillEffectUse > 0)
            {
                buttonGenerator.color = Color.red;
                drillEffect.Stop();
                emissorDrill.Stop();
                drillEffectUse = 0;
            }
        }
    }
    void DeleteGroundFake()
    {
        fakeGround.SetActive(false);
        encenderScene = false;
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        //this.enabled = false;
    }
}
