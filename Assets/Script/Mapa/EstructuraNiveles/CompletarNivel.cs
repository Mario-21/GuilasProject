using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletarNivel : MonoBehaviour, IDataPersistence
{
    [Header("Datos del Nivel")]
    [SerializeField] private string idNivel;
    [SerializeField] private bool triggerPasarNivel;
    [ContextMenu("Generar ID del Nivel")]
    private void GenerateGuid()
    {
        idNivel = System.Guid.NewGuid().ToString();
    }

    [Header("Información del Siguiente Nivel")]
    public int siguienteNivel;
    [SerializeField] BloquearMovimientoPlayer blockPlayer;


    public void LoadData(GameData gameData)
    {
        gameData.nivelesComplete.TryGetValue(idNivel, out triggerPasarNivel);
        if (triggerPasarNivel)
        {
            Debug.Log("Este Nivel ya ha sido pasado");
        }
    }

    public void SaveData(ref GameData gameData)
    {
        if (gameData.nivelesComplete.ContainsKey(idNivel))
        {
            //Ahora ya se pueden ver las Keys
            gameData.nivelesComplete.Remove(idNivel);
        }
        gameData.nivelesComplete.Add(idNivel, triggerPasarNivel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            triggerPasarNivel = true;
            /* /////////////////////////////////// */
            //Cuando acabes un nivel, te reestablecera la posibilidad de volver a cargar tu munición ya que la DataPlayer se elimina, n
            //blockPlayer.pistol.ammoData = true;
            //Guardar GameData
            DataPersistenceManager.instance.SaveGame();
            //Bloqueamos las acciones del Jugador
            blockPlayer.BloquearMovPlayer();
            //Limpiamos los sonidos para cambiar de zona
            AudioManager.instancia.CleanUp();
            MusicAmbienceManager.instance.CleanAmbienceMusic();
            //Colocamos a que nivel te diriges
            EstructuraNiveles.nivel = siguienteNivel;
            //Llamamos al "Fundido a negro".
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
            //Reestablecemos los checkpoints
            CheckPointController.numeroCheckPoint = 0;
            //Limpiamos el inventario
            InventoryManager.instanciaInventory.indexInventoryPosition = 0;
            //Limpiamos todos los objetivos
            MostrarTextObjectives.indexLine = 0;

            //Destruye las listas del nivel
            for(int e = 0; e < ListDestroyEndLevel.levelList.levelListDestroy.Count; e++)
            {
                Destroy(ListDestroyEndLevel.levelList.levelListDestroy[e].gameObject);
                Debug.Log("La Lista " + ListDestroyEndLevel.levelList.levelListDestroy[e].name + " ha sido eliminada");
                
            }
            Destroy(ListDestroyEndLevel.levelList.gameObject);
        }

    }
}
