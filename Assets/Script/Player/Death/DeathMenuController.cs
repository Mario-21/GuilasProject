using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
    //Al salir debes llamar a todas las listas para destruirlas
    //Resetear Todos los datos del Jugador 
    //vida (Se destruye por ende no es necesario reestablecerlo)
    //municion debe conservar la ultima que tuviste
    //
    public Animator animDeath;
    [Header("Death Exit")]
    public int mainMenuScene;
    [Header("Reanudar Gameplay")]
    public int out_MenuPausa;

    public void ExitMainMenu(string name)
    {
        //Detener Sonido
        AudioManager.instancia.CleanUp();
        MusicAmbienceManager.instance.CleanAmbienceMusic();
        //La vida del Player, dado que aun no se conserva 
        animDeath.SetTrigger(name);
        //Restablece el checkpoint a 0
        CheckPointController.numeroCheckPoint = 0;
        //Regresa al menu principal
        EstructuraNiveles.nivel = mainMenuScene;
        //Restablece las posiciones del inventario
        InventoryManager.instanciaInventory.indexInventoryPosition = 0;

        //Restablece las notas
        //Esto te da igual dado que en cuanto salgas se va a destruir, ya no permanece como una variable static
        //MostrarTextObjectives.indexLine = 0;

        //Destruye todas las listas 
        for (int e = 0; e < ListDestroyEndLevel.levelList.levelListDestroy.Count; e++)
        {
            Destroy(ListDestroyEndLevel.levelList.levelListDestroy[e].gameObject);
            Debug.Log("La Lista " + ListDestroyEndLevel.levelList.levelListDestroy[e].name + " ha sido eliminada");
        }
        Destroy(ListDestroyEndLevel.levelList.gameObject);
        //Poder Restablecer el menu
        PauseMenu.openTries = 0;
    }
    public void ReiniciarNivel(string nameReset)
    {
        //Detener Sonido
        AudioManager.instancia.CleanUp();
        MusicAmbienceManager.instance.CleanAmbienceMusic();
        animDeath.SetTrigger(nameReset);
        //Reinicia el checkpoint para que te envie a spawn del inicio del nivel
        CheckPointController.numeroCheckPoint = 0;
        //Enviame a la primera zona de esta seccion del nivel
        //En este caso si destruyo el StartSceneLevelCampaign cabe la posibilidad que de error la ejecucion, ya que no dejaria de existir y perderia la info
        //Solo queda 3:
        //1.Resetear los datos de las listas sin destruirlos
        //2.Hacer que esto se destruya aparte dado que no se modifica y permanecera statico
        //3.Cambiar la ejecucion de StartSceneLevelCampaign
        EstructuraNiveles.nivel = StartSceneLevelCampaign.infoActualCampaign.firstActualSceneCampaign;
        //Restablece las notas
        ObjectivesLevels.instanceObjectivesLevel.indexLine = 0;
        //Restablece las posiciones del inventario
        InventoryManager.instanciaInventory.indexInventoryPosition = 0;

        //Destruir las listas no se si funcionara debido a que no se si entrara en conflicto con lo demás
        //Destruir listas(?)
        //Ya no puedo destruirlas debo limpiarlas

        /*
        for (int e = 0; e < ListDestroyEndLevel.levelList.levelListDestroy.Count; e++)
        {
            Destroy(ListDestroyEndLevel.levelList.levelListDestroy[e].gameObject);
            Debug.Log("La Lista " + ListDestroyEndLevel.levelList.levelListDestroy[e].name + " ha sido eliminada");

        }
        Destroy(ListDestroyEndLevel.levelList.gameObject);
        */

        //Limpiar Todas las listas de los niveles
        ////Resetear AmmoRecovery en el nivel
        AmmoRecoveryList.ammoFromLevel.ResetearAmmo();
        //Resetear Items en el nivel
        SaveScene.instancia.ResetearItemNivel();
        //Resetear UI Items en el nivel
        if (ListaItemsUI.listaItemsUI != null) ListaItemsUI.listaItemsUI.ResetearItemUI(); Debug.Log("ListaUI Reseteada");
        //Resetear Variables en el nivel.
        StatusGameobjectsVariables.statusGameobject.ResetearVariable();
        //Resetear DataPlayer en el nivel
        ListDataPlayer.listDataPlayer.ResetearDataPlayer();
        //Resetear soldados en el nivel
        if (SoldierActiveInScene.instancia != null) SoldierActiveInScene.instancia.ResetearStatusSoldier();
        /*
        //Listas Especiales
        //Resetear DataAgua del nivel 12
        ListWaters.listWaters.ResetearAgua();
        //Resetear Turnos del nivel 11
        TurnosWorked.extras.ResetearTurnoWorker();
        //Resetear Timer del nivel 6
        NoviceSoldier.noviceDeathLife.ResetearTimeSoldier();
        //Resetear Ropa cesto del nivel 7
        ClotheData.clotheInfo.ResetearClothe();
        //Resetear Liquidos del nivel 7
        LiquidColor.liquid.ResetearLiquid();
        */


        //Poder Restablecer el menu
        PauseMenu.openTries = 0;
        //Mirar estado Reliquia para resetear
        //La condición del número la realizo para los posibles niveles donde no haya ninguna reliquia 
        if(ListaReliquias.instancia.numReliquiaNivel >= 0) GameDataNoDestroy.instance.CambiarGuardadoReliquia(ListaReliquias.instancia.numReliquiaNivel, ListDataPlayer.listDataPlayer.reliquiaObtenida);
    }
    public void Reanudar()
    {
        Debug.Log(Time.timeScale + " actual");
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(out_MenuPausa);
        //Poder Restablecer el menu
        PauseMenu.openTries = 0;
        PauseMenu.pause = false;
    }
}
