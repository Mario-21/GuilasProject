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
    [Header("Lista Campaigns")]
    public int indexCampaign;
    public List<InfoMenuCampaign> listaCampaign;
    public void FlechaDerecha()
    {
        if (indexCampaign < listaCampaign.Count - 1)
        {
            indexCampaign++;
        }
        ChangeInfoLevel();
        Debug.Log("Balon");

    }
    public void FlechaIzquierda()
    {
        if (indexCampaign > 0)
        {
            indexCampaign--;
        }
        ChangeInfoLevel();

    }
    public void ChangeInfoLevel()
    {
        titulo.text = listaCampaign[indexCampaign].tituloNivel;
        nivel = listaCampaign[indexCampaign].nivelScene;
        imagenNivel.sprite = listaCampaign[indexCampaign].imagenNivel;

    }
}
