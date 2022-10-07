using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBoneCin : MonoBehaviour
{
    [Header("Cinematic Info")]
    public int indexMod;
    public int cinematicLevel;
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;
    [Header ("Conditions Play Cinematic")]
    [SerializeField] SoldierLife boneSoldier;

    ActivarModificador activador;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ActivateCine();
        OffModificador();
    }
    void ActivateCine()
    {
        if (activador.modificacion && boneSoldier.vida >= 1)
        {
            bloqPlayer.BloquearMovPlayer();
            EstructuraNiveles.nivel = cinematicLevel;
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
    void OffModificador()
    {
        if(boneSoldier.vida <= 0)
        {
            activador.enabled = false;
        }
    }
}
