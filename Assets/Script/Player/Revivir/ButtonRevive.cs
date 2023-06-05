using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRevive : MonoBehaviour
{
    Revive revivirScene;
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
    public void ButtonResetAmmo()
    {
        revivirScene.ResetearMunicion();
    }
    public void ReloadScene()
    {
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
    }
}
