using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondUsePowderBoss : MonoBehaviour
{
    public int indexHuella;
    [Header("Soldado Powder")]
    [SerializeField] SoldierLife jefeMedico;
    [SerializeField] ColocarCuerda obtenerHuella;
    [SerializeField] ActivarModificador activadorBata;
    [Header("Mesa Powder")]
    [SerializeField] GunpowderUse gunpowderMesa;

    int once;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!StatusGameobjectsVariables.statusGameobject.modificacion[indexHuella].modificacion && jefeMedico.vida <= 0)
        {
            if(once < 1)
            {
                ChangeGunpowderUse();
                once++;
            }
        }
    }
    void ChangeGunpowderUse()
    {
        gunpowderMesa.enabled = false;
        obtenerHuella.enabled = true;
        activadorBata.enabled = true;
    }
}
