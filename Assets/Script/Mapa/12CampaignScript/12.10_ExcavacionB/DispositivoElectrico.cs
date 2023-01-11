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

    int once;
    bool luzOn;
    PlayerHere player;

    void Start()
    {
        player = GetComponent<PlayerHere>();
        luzOn = StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion;
        once = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ImDispositivo();
        if (player.playerImHere)
        {
            PressLuz();
        }
    }
    void PressLuz()
    {
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            luzOn = !luzOn;
            once = 0;
            SwitchLuz();

            TipoDispositivo dispositivo = new TipoDispositivo();
            dispositivo.GastoElectrico(ref ExtraVariable.extras.valorGenerador, gastoElectrico,  ref luzOn, ref once);
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
}
