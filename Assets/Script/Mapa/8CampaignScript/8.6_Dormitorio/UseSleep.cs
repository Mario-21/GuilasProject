using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSleep : MonoBehaviour
{
    public int indexMod;
    ActivarModificador activador;

    public int cinematicDormitorio;
    public int spawn;
    public SoldierLife soldadoDiary;

    BloquearMovimientoPlayer bloqPlayer;
    private void Awake()
    {
        bloqPlayer = FindObjectOfType<BloquearMovimientoPlayer>();
    }
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            this.enabled = false;
            activador.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (soldadoDiary.vida > 0 && !soldadoDiary.GetComponent<SoldadoNormal>().berserker) UseSleepPowder();
        else if (soldadoDiary.vida <= 0 || soldadoDiary.GetComponent<SoldadoNormal>().berserker) activador.enabled = false;
    }
    void UseSleepPowder()
    {
        if (activador.modificacion)
        {
            bloqPlayer.BloquearMovPlayer();
            EstructuraNiveles.nivel = cinematicDormitorio;
            CheckPointController.numeroCheckPoint = spawn;
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
        }
    }
}
