using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListMissions : MonoBehaviour
{
    public static ListMissions instanceMissions;

    public int numMissionsSuccessTotal;
    public int numMissionsSuccess;

    public List<MainMission> missionsLevel;
    public List<MainMission> missionsLevelInicial;

    public List<string> definicionSiguienteNivel;

    private void Awake()
    {
        if (ListMissions.instanceMissions == null)
        {
            ListMissions.instanceMissions = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //Esto determinará si ya se hizo una fotografía previamente o no

        for (int i = 0; i < missionsLevel.Count; i++)
        {
            MainMission mission = new MainMission();

            mission.nameMission = missionsLevel[i].nameMission;
            mission.idMission = missionsLevel[i].idMission;
            mission.indexListMissions = missionsLevel[i].indexListMissions;
            GameDataNoDestroy.instance.gameData.missionsComplete.TryGetValue(missionsLevel[i].idMission, out mission.success);

            missionsLevelInicial.Add(mission);
        }
    }
    public void ResetearMissiones()
    {
        //Reestableces el número de misiones completadas
        numMissionsSuccess = 0;

        //Reestableces la lista de misiones para volver a hacerlas
        for (int i = 0; i < missionsLevel.Count; i++)
        {
            missionsLevel[i].success = false;

            //Si la mision inicialmente NO estaba guardada en la data, eso quiere decir que nunca se llego a cumplir previamente,
            //por tanto, hay que resetearla
            if (!missionsLevelInicial[i].success)
            {
                if (GameDataNoDestroy.instance.gameData.missionsComplete.ContainsKey(missionsLevel[i].idMission))
                {
                    GameDataNoDestroy.instance.gameData.missionsComplete.Remove(missionsLevel[i].idMission);

                }
                GameDataNoDestroy.instance.gameData.missionsComplete.Add(missionsLevel[i].idMission, missionsLevelInicial[i].success);

                //missionLevelData ----> Es el mismo contenido que tendrá el GameDataNoDestroy, pero con el bool final de las missionsLevelInicial,
                //quiza deba hacer un missionLevelData = new missionLevelData(), para establecer toda la data de este aquí y poder añadirlo, pero 
                //como de momento no tengo nada metido, pues se queda así, por ahora.
            }
            else
            {
                Debug.Log("La mision principal " + missionsLevelInicial[i].nameMission + " ya ha sido completada.");
            }

        }
    }
    /*
    Esto hay que ver donde llamarlo, dado que esto se destruira en cuanto cambies de nivel y al pasarte el nivel llama también a definición de nivel.
    Podría colocarle como condicion si Mision == null realiza el normal, con el nombre de la siguiente pantalla de carga que tiene asignada CompletarNivel().
    Si existe Mission != null debo de llamar a esto que tengo debajo

    Otra opción es la de tener un script aparte de CompletarNivel() que se encargue de esto o un enum en el mismo con Default y Misiones y ya dependiendo
    de lo que elijas llama a una cosa u otra
    */
    public void MisionesCompletasPantallaCarga()
    {
        switch (numMissionsSuccess)
        {
            case 0:
                ControladorListasNivel.nombreSiguienteNivel = definicionSiguienteNivel[0];
                break;
            case 1:
                ControladorListasNivel.nombreSiguienteNivel = definicionSiguienteNivel[1];
                break;
            case 2:
                ControladorListasNivel.nombreSiguienteNivel = definicionSiguienteNivel[2];
                break;
            case 3:
                ControladorListasNivel.nombreSiguienteNivel = definicionSiguienteNivel[3];
                break;


        }
    }

    [ContextMenu("Genera una ID aleatoria a todas las misiones de la Lista")]
    private void GenerarIDMisiones()
    {
        for (int i = 0; i < missionsLevel.Count; i++)
        {
            missionsLevel[i].idMission = "";
            int limiteCharacter = 0;
            string id = System.Guid.NewGuid().ToString();
            foreach (char character in id)
            {
                if (limiteCharacter <= 8)
                {
                    Debug.Log(limiteCharacter);
                    missionsLevel[i].idMission += character;
                    limiteCharacter++;
                }
            }
        }
    }
}
[System.Serializable]
public class MainMission
{
    //EL nombre es una referencia para mí
    public string nameMission;
    //La id es para poder identificar en el GameDataNoDestroy
    public string idMission;
    //Esto quiza lo pongo para que no busque nada y directamente sepa su posición
    public int indexListMissions;
    //Saber si has logrado la mision o no.
    public bool success;
}
