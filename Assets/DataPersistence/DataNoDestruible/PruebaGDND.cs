using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaGDND : MonoBehaviour
{
    public bool displayTutorial;
    public string idNivel;
    public string idReliquia;
    public void NivelCompletado() 
    {
        if (GameDataNoDestroy.instance.gameData.nivelesComplete.ContainsKey(idNivel))
        {
            GameDataNoDestroy.instance.gameData.nivelesComplete.Remove(idNivel);
        }
        GameDataNoDestroy.instance.gameData.nivelesComplete.Add(idNivel, displayTutorial);
        Debug.Log("Te has pasado el nivel " + idNivel);
    }
    public void RecogerReliquia()
    {
        //Colocar en Dictionary que has obtenido la reliquia sin guardarla
        if (GameDataNoDestroy.instance.gameData.reliquiasCollected.ContainsKey(idReliquia))
        {
            GameDataNoDestroy.instance.gameData.reliquiasCollected.Remove(idReliquia);
            //GameDataNoDestroy.instance.gameData.nivelesComplete.Add(idReliquia, reliquiaRecogida);
        }
        GameDataNoDestroy.instance.gameData.reliquiasCollected.Add(idReliquia, displayTutorial);
        Debug.Log("Te has pasado el nivel " + idReliquia);
    }
    public void GuardarBoton()
    {
        GameDataNoDestroy.instance.SaveGame();
    }
    public void CargarBoton()
    {
        GameDataNoDestroy.instance.LoadGame();
    }
    public void ListaSinExistir()
    {
        ListWaters.listWaters.ResetearAgua();
    }
}
