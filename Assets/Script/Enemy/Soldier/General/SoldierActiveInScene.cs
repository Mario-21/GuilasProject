using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierActiveInScene : MonoBehaviour
{
    public static SoldierActiveInScene instancia;

    public bool activeAllAttackSoldiers;
    public bool warningAllSoldiers;

    public List<ListaStatusSoldierScenes> soldiersStatus;
    [HideInInspector] public List<ListaStatusSoldierScenes> soldierStatusInicial;

    int soldierInAttack;
    int soldierInWarning;

    private void Awake()
    {
        if (SoldierActiveInScene.instancia == null)
        {
            SoldierActiveInScene.instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        for (int i = 0; i < soldiersStatus.Count; i++)
        {
            ListaStatusSoldierScenes soldadoStart = new ListaStatusSoldierScenes();

            soldadoStart.soldierName = soldiersStatus[i].soldierName;
            soldadoStart.statusVida = soldiersStatus[i].statusVida;

            soldierStatusInicial.Add(soldadoStart);
        }
    }
    public void ResetearStatusSoldier()
    {
        activeAllAttackSoldiers = false;
        warningAllSoldiers = false;

        soldierInAttack = 0;
        soldierInWarning = 0;

        for (int i = 0; i < soldiersStatus.Count; i++)
        {
            soldiersStatus[i].statusVida = soldierStatusInicial[i].statusVida;
            soldiersStatus[i].berserkerStatus = false;
            soldiersStatus[i].imDead = false;
            soldiersStatus[i].warningSoldier = false;
            soldiersStatus[i].deathScene = 0;
        }
    }
    #region Esto seguramente lo acabe modificando dado que creo que hay maneras más simples de ejecutarlo.
    public void AllActiveAttack()
    {
        for (int i = 0; i < soldiersStatus.Count; i++)
        {
            if (soldiersStatus[i].berserkerStatus)
            {
                soldierInAttack++;
            }
        }
        if (soldierInAttack >= soldiersStatus.Count)
        {
            activeAllAttackSoldiers = true;
        }
    }
    public void AllWarningActive()
    {
        for (int i = 0; i < soldiersStatus.Count; i++)
        {
            if (soldiersStatus[i].warningSoldier)
            {
                soldierInWarning++;
            }
        }
        if (soldierInWarning >= soldiersStatus.Count)
        {
            warningAllSoldiers = true;
        }
    }
    public void UnactiveAllWarning()
    {
        foreach (ListaStatusSoldierScenes statusSoldierMode in soldiersStatus)
        {
            statusSoldierMode.warningSoldier = false;
            soldierInWarning--;
        }
        if (soldierInWarning <= soldiersStatus.Count)
        {
            warningAllSoldiers = false;
        }
    }
    #endregion
}
