using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataNiveles : MonoBehaviour,IDataPersistence
{
    public ListCampaign listaCampanyas;
    [SerializeField] private int keyIdentificador = 0;
    [SerializeField] private int keyIdReliquias = 0;
    public int nivelesCompletados;
    public Image iconCompleteLevel;
    public void LoadData(GameData gameData)
    {
        //Primero compruebas que el keyIdentificador sea mas pequenyo que la lista de Keys dentro del dictionary
        //Esto lo haces para que cuando termine de asignar todas los niveles, se corte y acabe la ejecucion, un limitador
        if(keyIdentificador < gameData.nivelesComplete.keys.Count)
        {
            //Va mirando dentro de la lista de niveles cual coincide con la respectiva ID
            for (int i = 0; i < listaCampanyas.listaCampaign.Count; i++)
            {
                if (listaCampanyas.listaCampaign[i].idNivel == gameData.nivelesComplete.keys[keyIdentificador])
                {
                    //Cuando encuentra la ID comprueba si el nivel ha sido completado
                    listaCampanyas.listaCampaign[i].complete = gameData.nivelesComplete.values[keyIdentificador];
                    keyIdentificador++;
                    //Tambien podría colocar aqui las reliquias, dado que para obtener una, SIEMPRE, te has tenido que pasar el nivel antes. 
                }
            }
            Debug.Log("Ha terminado el bucle y no ha encontrado ningun nivel más pasado, el último nivel pasado ha sido: Nivel " + keyIdentificador);
        }

        int w = 0;

        while (w < listaCampanyas.listaCampaign.Count)
        {
            if (!string.IsNullOrEmpty(listaCampanyas.listaCampaign[w].idReliquia))
            {
                if(listaCampanyas.listaCampaign[w].idReliquia == gameData.reliquiasCollected.keys[keyIdReliquias])
                {
                    listaCampanyas.listaCampaign[w].onReliquia = gameData.reliquiasCollected.values[keyIdReliquias];
                    keyIdReliquias = 0;
                    w++;
                }
                else if(listaCampanyas.listaCampaign[w].idReliquia != gameData.reliquiasCollected.keys[keyIdReliquias])
                {
                    keyIdReliquias++;
                }
            }
            else if (string.IsNullOrEmpty(listaCampanyas.listaCampaign[w].idReliquia))
            {
                w++;
            }
        }
    }

    public void SaveData(ref GameData gameData)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
            NivelesCompletados();

    }

    // Update is called once per frame
    void Update()
    {
        if (nivelesCompletados < listaCampanyas.listaCampaign.Count)
        {
            DesbloquearNiveles();
            //Imagen del nivel completado
        }
        UICompleteNivel();
    }

    void NivelesCompletados()
    {
        for (int i = 0; i < listaCampanyas.listaCampaign.Count; i++)
        {
            if (listaCampanyas.listaCampaign[i].complete)
            {
                nivelesCompletados++;
            }
        }
    }
    void DesbloquearNiveles()
    {
        //Solo desbloque el nivel actual
        if (listaCampanyas.indexCampaign == nivelesCompletados)
        {
            listaCampanyas.buttonNivel.interactable = true;
            iconCompleteLevel.enabled = false;
        }
        else if (listaCampanyas.indexCampaign != nivelesCompletados)
        {
            listaCampanyas.buttonNivel.interactable = false;
        }
    }
    void UICompleteNivel()
    {
        if (listaCampanyas.listaCampaign[listaCampanyas.indexCampaign].complete)
        {
            iconCompleteLevel.enabled = true;
        }
        else
        {
            iconCompleteLevel.enabled = false;
        }
    }
}
