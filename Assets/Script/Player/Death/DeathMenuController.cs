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
        MostrarTextObjectives.indexLine = 0;
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
        MostrarTextObjectives.indexLine = 0;
        //Restablece las posiciones del inventario
        InventoryManager.instanciaInventory.indexInventoryPosition = 0;
        //Destruir las listas no se si funcionara debido a que no se si entrara en conflicto con lo demás
        //Destruir listas(?)
        for (int e = 0; e < ListDestroyEndLevel.levelList.levelListDestroy.Count; e++)
        {
            Destroy(ListDestroyEndLevel.levelList.levelListDestroy[e].gameObject);
            Debug.Log("La Lista " + ListDestroyEndLevel.levelList.levelListDestroy[e].name + " ha sido eliminada");

        }
        Destroy(ListDestroyEndLevel.levelList.gameObject);
        //Poder Restablecer el menu
        PauseMenu.openTries = 0;
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
