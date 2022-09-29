using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanOpenChest : MonoBehaviour
{
    public int indexSoldSleep;
    ActivarModificador activador;

    [Header("When Soldier Sleep")]
    [SerializeField] AbrirCofre abrirCofre;
    [SerializeField] SoldierLife soldadoDiary;
    [Header("When Soldier No Sleep")]
    [SerializeField] Detectar_y_Echar secuence;
    [SerializeField] SaveButton keyButton;
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        CanOpen();
    }

    // Update is called once per frame
    void Update()
    {
        CanOpen();
        NoOpenMyChest();
    }
    void CanOpen()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexSoldSleep].modificacion || soldadoDiary.vida <= 0)
        {
            abrirCofre.enabled = true;
            this.enabled = false;
        }
    }
    void NoOpenMyChest()
    {
        if (activador.modificacion)
        {
            secuence.Secuence();
            bloqPlayer.BloquearMovPlayer();
            //Reset the button to not disabled her use
            SaveScene.instancia.listaItemsNivelGuardar[keyButton.indexButton].vecesUsadoObjeto = 0;

        }
    }
}
