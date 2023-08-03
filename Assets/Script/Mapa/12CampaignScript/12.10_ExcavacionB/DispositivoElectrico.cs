using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        player = GetComponent<PlayerHere>();
        luzOn = StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.pause)ImDispositivo();
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
