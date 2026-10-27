using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCaveCin : MonoBehaviour
{
    public int indexMod;
    public int indexActiveCin;
    [Header("Cinematic")]
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;
    public int cinematicCaveLevel;
    bool playerOnCin;
    void Start()
    {
        //Se desactivara si la cinemática ya se ha realizado o si el no se puede dar las condiciones para que la cinemática se active
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion ||
            !StatusGameobjectsVariables.statusGameobject.modificacion[indexActiveCin].modificacion) this.enabled = false;
    }
    void Update()
    {
        CaveCin();
    }
    void CaveCin()
    {
        if (playerOnCin)
        {
            bloqPlayer.BloquearMovPlayer();
            EstructuraNiveles.nivel = cinematicCaveLevel;
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) playerOnCin = true;
    }
}
