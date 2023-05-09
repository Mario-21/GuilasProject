using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListCampaign : MonoBehaviour
{
    [Header("Componenetes del Menu Campaign")]
    public Text titulo;
    public Image imagenNivel;
    public int nivel;
    public int indexReliquia;
    public Image contornoReliquia;
    public Image imagenReliquia;
    [Header("Condiciones Reliquia")]
    public int minRange;
    public int maxRange;
    [Header("Lista Campaigns")]
    public int indexCampaign;
    public List<InfoMenuCampaign> listaCampaign;
    private void OnDisable()
    {
        indexCampaign = 0;
        indexReliquia = 0;
        ChangeInfoLevel();
    }
    public void FlechaDerecha()
    {
        ConditionsReliquiaIncrease();
        if (indexCampaign < listaCampaign.Count - 1)
        {
            indexCampaign++;
        }
        ChangeInfoLevel();
        //ConditionsReliquiaIncrease();

    }
    public void FlechaIzquierda()
    {
        ConditionsReliquiaDecrease();
        if (indexCampaign > 0)
        {
            indexCampaign--;
        }
        ChangeInfoLevel();
        //ConditionsReliquiaDecrease();

    }
    public void ChangeInfoLevel()
    {
        titulo.text = listaCampaign[indexCampaign].tituloNivel;
        nivel = listaCampaign[indexCampaign].nivelScene;
        imagenNivel.sprite = listaCampaign[indexCampaign].imagenNivel;
        //Reliquias
        contornoReliquia.sprite = listaCampaign[indexCampaign].reliquiaContorno;
        imagenReliquia.sprite = listaCampaign[indexCampaign].reliquiaImage;

    }
    void ConditionsReliquiaIncrease()
    {
        if (listaCampaign[indexCampaign].onReliquia)
        {
            if(indexReliquia < maxRange)
            {
                indexReliquia++;
            }
            //no puede ser mayor que el rango
            
        }
    }
    void ConditionsReliquiaDecrease()
    {
        if (listaCampaign[indexCampaign].onReliquia && indexCampaign > minRange)
        {
            if(indexReliquia > 0)
            {
                indexReliquia--;
            }
            
        }
    }
}
