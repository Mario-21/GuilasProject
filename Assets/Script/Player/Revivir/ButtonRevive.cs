using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRevive : MonoBehaviour
{
    [Header("Info Reload")]
    public Animator transicionPause;
    public void ButtonReviveScene()
    {
        //Restaura las variables del último punto de guardado
        Revive.instanceRevive.ResetearVariablesZona();
        //Restaura las municiones del último punto de guardado
        Revive.instanceRevive.ResetearAmmo();
        //Restaura las reliquias del último punto de guardado, si no se habían guardado al finalizar el nivel
        Revive.instanceRevive.ResetarReliquiasZona();
        //Restaura los items del último punto de guardado
        Revive.instanceRevive.ResetearItemsZona();
        //Restaura el estado de los soldados del último punto de guardado
        if(SoldierActiveInScene.instancia != null) Revive.instanceRevive.ResetearSoldado();
        //Restaura las balas del último punto de guardado
        Revive.instanceRevive.ResetearMunicionPlayer();
        //Restaura los itemsUI del último punto de guardado, en caso de que exista
        if(ListaItemsUI.listaItemsUI != null) Revive.instanceRevive.ResetearUiItems();
        //Restaura las posiciones en el inventario del último punto de guardado 
        Revive.instanceRevive.ResetearInventoryPos();
        //Restaura la vida del player del último punto de guardado
        Revive.instanceRevive.ResetearVida();
        //Restaura la notas del último punto de guardado
        Revive.instanceRevive.ResetearNote();
        //Restaura los liquidos del último punto de guardado del nivel 6
        if(LiquidColor.liquid != null )Revive.instanceRevive.ReviveLiquid();
        //Restaura la ropa del último punto de guardado del nivel 7
        if (ClotheData.clotheInfo != null) Revive.instanceRevive.ReviveClothe();
        //Restaura los turnos del último punto de guardado del nivel 11
        if (TurnosWorked.extras != null) Revive.instanceRevive.ReviveTurns();
        //Restaura las aguas del último punto de guardado del nivel 12
        if (ListWaters.listWaters != null) Revive.instanceRevive.ReviveWater();
        //Restaura las misiones del último punto de guardado del nivel 8,9,10
        if (ListMissions.instanceMissions != null) Revive.instanceRevive.ReviveMissions();
        //Restaurar el estado de los últimos tutoriales del último punto de guardado 
        if (ControlerTutoriales.instanciaTutoriales != null) Revive.instanceRevive.RevivirTutoriales();
    }


    public void ButtonResetTerminales()
    {
        //if (TotalTerminales.terminalesTotales != null) revivirScene.ResetearTerminales();
    }
    public void ReloadScene(string name)
    {
        transicionPause.SetTrigger(name);
        PauseMenu.openTries = 0;
        PauseMenu.pause = false;
        
    }
}
