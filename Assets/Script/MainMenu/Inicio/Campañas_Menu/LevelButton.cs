using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public ListCampaign mainCampaign;
    public void SelectLevel()
    {
        //Checkpoint Inicial
        CheckPointController.numeroCheckPoint = 0;
        //Nivel al que te diriges
        EstructuraNiveles.nivel = mainCampaign.listaCampaign[mainCampaign.indexCampaign].nivelScene;
        //Llama la Animacion
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
        //level = nivelasia;
        Debug.Log("Me voy al level " + mainCampaign.listaCampaign[mainCampaign.indexCampaign].nivelScene);
    }
}
