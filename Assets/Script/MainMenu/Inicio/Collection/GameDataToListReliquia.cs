using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataToListReliquia : MonoBehaviour, IDataPersistence
{
    int keyRelic;
    public void LoadData(GameData gameData)
    {
        int i = 0;

        while (i < ListaReliquias.instancia.listaReliquiasTotal.Count)
        {
            if (ListaReliquias.instancia.listaReliquiasTotal[i].idReliquia == gameData.reliquiasCollected.keys[keyRelic])
            {
                ListaReliquias.instancia.listaReliquiasTotal[i].reliquiaObtenida = gameData.reliquiasCollected.values[keyRelic];
                i++;
                keyRelic = 0;
            }
            else if (ListaReliquias.instancia.listaReliquiasTotal[i].idReliquia != gameData.reliquiasCollected.keys[keyRelic])
            {
                keyRelic++;
            }
        }
    }

    public void SaveData(ref GameData gameData)
    {
        
    }
}
