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
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (soldadoDiary.vida > 0) UseSleepPowder();
        else if (soldadoDiary.vida <= 0) activador.enabled = false;
    }
    void UseSleepPowder()
    {
        if (activador.modificacion)
        {
            EstructuraNiveles.nivel = cinematicDormitorio;
            CheckPointController.numeroCheckPoint = spawn;
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
        }
    }
}
