using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    [Header("Variables Nivel")]
    public List<bool> variablesStartLevel;
    [Header("Items Nivel")]
    public List<bool> itemsStartLevel;
    [Header("Reliquias Nivel")]
    public List<bool> reliquiaStartLevel;
    [Header("Enemies Nivel")]
    public List<ListaStatusSoldierScenes> vidaSoldados;
    [Header("Terminales Nivel")]
    public List<bool> terminalesStartLevel;
    [Header("Municiones Nivel")]
    [SerializeField] ArmaController mainWeaponPlayer;
    public int municionStartLevel;
    void Start()
    {
        //Coloca la municion
        municionStartLevel = mainWeaponPlayer.municionTotal;

        for(int e = 0; e < variablesStartLevel.Count; e++)
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[e].modificacion)
            {
                variablesStartLevel[e] = true;
            }
        }
        for (int w = 0; w < itemsStartLevel.Count; w++)
        {
            if (SaveScene.instancia.listaItemsNivelGuardar[w].objetoObtenido)
            {
                itemsStartLevel[w] = true;
            }
        }
        for(int i = 0; i < reliquiaStartLevel.Count; i++)
        {
            if (ListaReliquias.listaReliquiasTotal[i].reliquiaObtenida)
            {
                reliquiaStartLevel[i] = true;
            }
        }
        for(int h = 0; h < vidaSoldados.Count; h++)
        {
            vidaSoldados[h].statusVida = SoldierActiveInScene.instancia.soldiersStatus[h].statusVida;
            vidaSoldados[h].modeSoldier = SoldierActiveInScene.instancia.soldiersStatus[h].modeSoldier;
        }
        if(TotalTerminales.terminalesTotales != null)
        {
            for (int k = 0; k < terminalesStartLevel.Count; k++)
            {
                if (TotalTerminales.terminalesTotales.terminalesActivos[k])
                {
                    terminalesStartLevel[k] = true;
                }
            }
        }
    }
    public void ResetearVariablesZona()
    {
        //Si son diferentes establece la variable a como estaba al inicio del nivel
        for (int w = 0; w < variablesStartLevel.Count; w++)
        {
            //Si son diferentes, quiere decir que lo acabas de modificar ahora pero has muerto en el proceso, por tanto debe resetearse
            if(StatusGameobjectsVariables.statusGameobject.modificacion[w].modificacion != variablesStartLevel[w])
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[w].modificacion = variablesStartLevel[w];
            }
        }
    }
    public void ResetearItemsZona()
    {
        for (int w = 0; w < itemsStartLevel.Count; w++)
        {
            //Si son diferentes, quiere decir que lo acabas de modificar ahora pero has muerto en el proceso, por tanto debe resetearse
            if (SaveScene.instancia.listaItemsNivelGuardar[w].objetoObtenido != itemsStartLevel[w])
            {
                SaveScene.instancia.listaItemsNivelGuardar[w].objetoObtenido = itemsStartLevel[w];
            }
        }
    }
    public void ResetarReliquiasZona()
    {
        for (int w = 0; w < itemsStartLevel.Count; w++)
        {
            //Si son diferentes, quiere decir que lo acabas de modificar ahora pero has muerto en el proceso, por tanto debe resetearse
            if (ListaReliquias.listaReliquiasTotal[w].reliquiaObtenida != reliquiaStartLevel[w])
            {
                ListaReliquias.listaReliquiasTotal[w].reliquiaObtenida = reliquiaStartLevel[w];
            }
        }
    }
    public void ResetearSoldado()
    {
        for (int w = 0; w < vidaSoldados.Count; w++)
        {
            //Si son diferentes, quiere decir que lo acabas de modificar ahora pero has muerto en el proceso, por tanto debe resetearse
            if (SoldierActiveInScene.instancia.soldiersStatus[w].statusVida != vidaSoldados[w].statusVida)
            {
                SoldierActiveInScene.instancia.soldiersStatus[w].statusVida = vidaSoldados[w].statusVida;
                SoldierActiveInScene.instancia.soldiersStatus[w].modeSoldier = vidaSoldados[w].modeSoldier;
            }
        }
    }
    public void ResetearTerminales()
    {
        for (int w = 0; w < terminalesStartLevel.Count; w++)
        {
            //Si son diferentes, quiere decir que lo acabas de modificar ahora pero has muerto en el proceso, por tanto debe resetearse
            if (TotalTerminales.terminalesTotales.terminalesActivos[w] != terminalesStartLevel[w])
            {
                TotalTerminales.terminalesTotales.terminalesActivos[w] = terminalesStartLevel[w];
            }
        }
    }
    public void ResetearMunicion()
    {
        mainWeaponPlayer.municionTotal = municionStartLevel;
    }
    //Tambien debe guardar la municion
}
