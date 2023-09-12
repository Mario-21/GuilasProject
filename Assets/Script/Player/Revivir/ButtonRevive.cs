using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRevive : MonoBehaviour
{
    public Revive revivirScene;
    [Header("Info Reload")]
    public Animator transicionPause;
    void Start()
    {
        revivirScene = FindObjectOfType<Revive>();
    }
    public void ButtonResetVariables()
    {
        revivirScene.ResetearVariablesZona();
    }
    public void ButtonResetItems()
    {
        revivirScene.ResetearItemsZona();
    }
    public void ButtonResetReliquias()
    {
        revivirScene.ResetarReliquiasZona();
    }
    public void ButtonResetEnemies()
    {
        revivirScene.ResetearSoldado();
    }
    public void ButtonResetTerminales()
    {
        if (TotalTerminales.terminalesTotales != null) revivirScene.ResetearTerminales();
    }
    public void ButtonResetAmmoPlayer()
    {
        revivirScene.ResetearMunicionPlayer();
    }
    public void ButtonResetAmmo()
    {
        revivirScene.ResetearAmmo();
    }
    public void ButtonResetearUiItems()
    {
        revivirScene.ResetearUiItems();
    }
    public void ReloadScene(string name)
    {
        transicionPause.SetTrigger(name);
        PauseMenu.openTries = 0;
        PauseMenu.pause = false;
        
    }
    public void ButtonResetearPosInventory()
    {
        revivirScene.ResetearInventoryPos();
    }
    public void ButtonResetearNote()
    {
        revivirScene.ResetearNote();
    }
}
