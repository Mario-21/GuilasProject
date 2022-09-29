using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSleep : MonoBehaviour
{
    public int indexMod;
    ActivarModificador activador;

    public int cinematicDormitorio;
    public SoldierLife soldadoDiary;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
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
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            EstructuraNiveles.nivel = cinematicDormitorio;
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
        }
    }
}
