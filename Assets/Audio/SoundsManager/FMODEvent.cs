using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvent : MonoBehaviour
{

    [Header("Music")]
    [SerializeField] public EventReference music;
    [Header("Ambience")]
    [SerializeField] public EventReference wind;
    [Header("Player SFX")]
    [SerializeField] string apartado_1;
    [SerializeField] public EventReference grassSteps;
    [SerializeField] public EventReference sandSteps;
    [SerializeField] public EventReference concreteSteps;
    [SerializeField] public EventReference metalSteps;
    [SerializeField] public EventReference woodSteps;
    [SerializeField] public EventReference caveSteps;
    [SerializeField] public EventReference mudSteps;
    [SerializeField] public EventReference forestSteps;
    [SerializeField] public EventReference wetSteps;
    [SerializeField] public EventReference swimSteps;
    [SerializeField] public EventReference ramaSteps;
    [Space(20)]
    [SerializeField] string apartado_2;
    [SerializeField] public EventReference woodLadder;
    [SerializeField] public EventReference stealLadder;
    [SerializeField] public EventReference ropeLadder;
    [SerializeField] public EventReference splashWater;
    [Space(20)]
    [SerializeField] string apartado_3;
    [SerializeField] public EventReference arbustoHidden;
    [SerializeField] public EventReference cajaHidden;
    [SerializeField] public EventReference taquillaHidden;
    [SerializeField] public EventReference basuraHidden;
    [SerializeField] public EventReference puertaHidden;
    [SerializeField] public EventReference containerHidden;
    [Space(20)]
    [SerializeField] string apartado_4;
    [SerializeField] public EventReference damage;
    [SerializeField] public EventReference electroDamage;
    [Space(20)]
    [SerializeField] string apartado_5;
    [SerializeField] public EventReference takeClothes;
    [SerializeField] public EventReference takeOffClothes;
    [SerializeField] public EventReference laundryClothes;
    [SerializeField] public EventReference lighterFire;
    [Space(20)]
    [SerializeField] string apartado_6;
    [SerializeField] public EventReference shoot;
    [SerializeField] public EventReference noAmmo;
    [SerializeField] public EventReference drawWeapon;
    [SerializeField] public EventReference outWeapon;
    [SerializeField] public EventReference recoveryAmmo;
    [SerializeField] public EventReference b8Lanzar;
    [SerializeField] public EventReference b8Recoger;
    [SerializeField] public EventReference b8CollisionGround;
    [SerializeField] public EventReference visionModeOn;
    [SerializeField] public EventReference visionModeOff;
    //CAMBIAR EL SOPNIDO DEL COCHE A AMBIENTE
    [Header("Soldier Enemy SFX")]
    [SerializeField] string apartado_1_Enemy;
    [SerializeField] public EventReference stepsEnemy;
    [Space(20)]
    [SerializeField] string apartado_2_Enemy;
    [SerializeField] public EventReference dañarEnemy;
    [SerializeField] public EventReference fallEnemy;
    [SerializeField] public EventReference sleepEnemy;
    [SerializeField] public EventReference drinkEnemy;
    [SerializeField] public EventReference angryEnemy;
    [Space(20)]
    [SerializeField] string apartado_3_Enemy;
    [SerializeField] public EventReference call;
    [SerializeField] public EventReference call_Cadaver;
    [Space(20)]
    [SerializeField] string apartado_4_Enemy;
    [SerializeField] public EventReference attackMode;
    [SerializeField] public EventReference searchMode;
    [SerializeField] public EventReference detect_CadaverMode;
    [SerializeField] public EventReference detect_NormalMode;
    [Header("Shark Enemy SFX")]
    [SerializeField] public EventReference biteAttack;
    [SerializeField] public EventReference nadarShark;
    [Header("Items Interactives SFX")]
    [SerializeField] string terminal;
    [SerializeField] public EventReference teclear;
    [SerializeField] public EventReference confirmTerminal;
    [SerializeField] string ascensor;
    [SerializeField] public EventReference botonGeneral;
    [SerializeField] public EventReference ascensorMove;
    [SerializeField] public EventReference ascensorAction;
    [SerializeField] string derrumbamiento;
    [SerializeField] public EventReference rumbling;
    [SerializeField] public EventReference explosion;
    [SerializeField] public EventReference failLight;
    [SerializeField] public EventReference goteoMetal;
    [SerializeField] string candado;
    [SerializeField] public EventReference cerrar_Abrir_Lock;
    [SerializeField] string campana;
    [SerializeField] public EventReference bell;
    [SerializeField] string notas;
    [SerializeField] public EventReference escribir;
    [SerializeField] public EventReference seeNote;
    [SerializeField] string enfermeria;
    [SerializeField] public EventReference holter;
    [SerializeField] string zona_comida;
    [SerializeField] public EventReference compuertaFood;
    [SerializeField] string lavanderia;
    [SerializeField] public EventReference finishWashingMachine;
    [SerializeField] string hook;
    [SerializeField] public EventReference hookBox;
    [SerializeField] string cameras;
    [SerializeField] public EventReference securityCamAlert;
    [SerializeField] public EventReference alarm;
    [SerializeField] string mesa_crafting;
    [SerializeField] public EventReference crafteo;
    [SerializeField] public EventReference endCrafteo;
    [SerializeField] string aparatos_electricos;
    [SerializeField] public EventReference drill;
    [SerializeField] public EventReference ventilador;
    [SerializeField] string sistema_drenaje;
    [SerializeField] public EventReference drenar;
    [SerializeField] public EventReference llenarDrenaje;
    [SerializeField] public EventReference valvula;
    [SerializeField] public EventReference rejillaOpen;
    [SerializeField] public EventReference rejillaClose;

    [Header("Temple SFX")]
    [SerializeField] string dardos;
    [SerializeField] public EventReference dardoShoot;
    [SerializeField] public EventReference dardoImpact;
    [SerializeField] string spear;
    [SerializeField] public EventReference spearActive;
    [SerializeField] public EventReference spearImpact;
    [SerializeField] public EventReference spearGear;
    [SerializeField] string traps;
    [SerializeField] public EventReference baldosaTrap;
    [SerializeField] public EventReference secretTemple;
    [Header("UI SFX")]
    [SerializeField] public EventReference retrocerder_UI;
    [SerializeField] public EventReference confirm_UI;
    [SerializeField] public EventReference error_UI;
    [SerializeField] public EventReference buttonAscensor_UI;
    [SerializeField] public EventReference writeNote_UI;
    [SerializeField] public EventReference sacarPaper_UI;
    [SerializeField] public EventReference lamp_UI;

    public static FMODEvent instancia;
    public void Awake()
    {
        if(FMODEvent.instancia == null)
        {
            FMODEvent.instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
