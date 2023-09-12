using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(PlayerHere))]
public class DispositivoElectrico : MonoBehaviour
{

    //Hacer un enum para especificar el tipo de dispositivo
    //Quiza incluso integrarle la resta en TipoDispositivo
    public int indexMod;
    public enum AparatoElectrico
    {
        Taladro,
        Ventilador,
        Foco
    }
    [Header("Tipo Aparato")]
    public AparatoElectrico aparato;

    [Header("Consumo Electrico")]
    public int gastoElectrico;

    [Header("Componentes Aparato")]
    public GameObject baseAparato;
    public float velocidad;
    public GameObject particles;

    [Header("Boton Color")]
    [SerializeField] SpriteRenderer colorButton;

    [HideInInspector] public bool luzOn;
    PlayerHere player;

    StudioEventEmitter emitterDispositive;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        luzOn = StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion;
        InitializedDispositivo();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.pause) 
        {
            ImDispositivo();
            Debug.Log("Sispotive");
        }
        ColorButton();
        if (player.playerImHere)
        {
            PressLuz();
        }
    }
    void PressLuz()
    {
        if (Input.GetButtonDown("Action")) 
        {
            luzOn = !luzOn;
            SwitchLuz();
            SoundDispositivo();

            TipoDispositivo dispositivo = new TipoDispositivo();
            dispositivo.GastoElectrico(ref TurnosWorked.extras.valorGenerador, gastoElectrico,  ref luzOn);
        }
    }
    void ImDispositivo()
    {
        switch (aparato)
        {
            case AparatoElectrico.Taladro:
                Taladro taladro = new Taladro();
                taladro.UseTaladro(ref luzOn, baseAparato, velocidad, particles);
                break;
            case AparatoElectrico.Ventilador:
                Ventilador ventilador = new Ventilador();
                ventilador.UseVentilador(ref luzOn, baseAparato, velocidad);
                break;
            case AparatoElectrico.Foco:
                Foco foco = new Foco();
                foco.UseFoco(ref luzOn, baseAparato);
                break;
        }
    }
    void SoundDispositivo()
    {
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
        switch (aparato)
        {
            case AparatoElectrico.Taladro:
                ApagarAudio();
                break;
            case AparatoElectrico.Ventilador:
                ApagarAudio();
                break;
            case AparatoElectrico.Foco:
                break;
        }
    }
    void ApagarAudio()
    {
        if (luzOn)
        {
            emitterDispositive.Play();
        }
        else
        {
            emitterDispositive.Stop();
        }
    }
    void InitializedDispositivo()
    {
        switch (aparato)
        {
            case AparatoElectrico.Taladro:
                emitterDispositive = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.drill, baseAparato);
                if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) emitterDispositive.Play();
                break;
            case AparatoElectrico.Ventilador:
                emitterDispositive = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.ventilador, baseAparato);
                if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) emitterDispositive.Play();
                break;
            case AparatoElectrico.Foco:
                break;
        }
    }
    void SwitchLuz()
    {
        if (luzOn)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
        else 
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = false;
        }
    }
    void ColorButton()
    {
        if (luzOn)
        {
            colorButton.color = Color.green;
        }
        else
        {
            colorButton.color = Color.red;
        }
    }
}
