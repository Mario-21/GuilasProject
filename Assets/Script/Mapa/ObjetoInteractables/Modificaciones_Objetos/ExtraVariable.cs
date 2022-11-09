using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraVariable : MonoBehaviour
{
    public static ExtraVariable extras;

    #region EndLoop(Nivel_4)
    [HideInInspector] public bool finalLoop;
    #endregion
    #region ViajeRapido(Nivel_ 4)
    [HideInInspector] public int usosViajeRapido = 1;
    #endregion
    #region Templo(Nivel_4)
    [HideInInspector] public bool activarTrampasTemplo;
    #endregion

    #region TheLastSoldiersFloor0(Nivel_6.3)
    [HideInInspector] public float xLastDeath;
    [HideInInspector] public float yLastDeath;
    [HideInInspector] public int onlyOne;
    #endregion
    #region B8(Best Weapon)(6.5)
    [HideInInspector] public int b8Reogida;
    [HideInInspector] public bool izqEscombrosB8;
    #endregion

    #region WakeUpDoctor(Nivel 7.4/Enfermeria)
    [HideInInspector] public int wakeUpDoctorSwitch;
    [HideInInspector] public int wakeUpDoctorNovice;
    #endregion
    #region Time Death Novice (7.1_Inicio)
    public float timeNoviceDeath;
    #endregion

    #region Type Of Drink (8.5_Bar)
    public int drink;
    #endregion
    #region Collect Clothes (8.6_Dormitorio)
    [HideInInspector] public int numClothes;
    #endregion
    #region Consumption (8.7_Laundry)
    [HideInInspector] public int consumption;
    #endregion

    #region GetUpScientific (9.4_SalaCientifico)
    [HideInInspector] public int actionOne;
    #endregion

    #region CinematicSelection (10.5_Comedor)
    public enum CinematicComedor105
    {
        Aspersor,
        Veneno
    }
    public CinematicComedor105 comedorScene;
    #endregion
    private void Awake()
    {
        if (ExtraVariable.extras == null)
        {
            ExtraVariable.extras = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
