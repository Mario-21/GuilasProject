using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListCampaign : MonoBehaviour
{
    [Header("Componenetes del Menu Campaign")]
    public Text titulo;
    public Image imagenNivel;
    public Button buttonNivel;
    public int nivel;
    public int indexReliquia;
    public Image contornoReliquia;
    public Image imagenReliquia;
    [Header("Condiciones Reliquia")]
    public string code;
    public int maxRange;
    [Header("Lista Campaigns")]
    public int indexCampaign;
    public string nombreEscenaCampaign;
    public int nivelesCompletados;
    public List<InfoMenuCampaign> listaCampaign;
    private void OnDisable()
    {
        indexCampaign = 0;
        indexReliquia = 0;
        ChangeInfoLevel();
    }
    private void Update()
    {
        ChangeInfoLevel();
    }
    public void FlechaDerecha()
    {
        if (indexCampaign < listaCampaign.Count - 1)
        {
            indexCampaign++;
        }

    }
    public void FlechaIzquierda()
    {
        if (indexCampaign > 0)
        {
            indexCampaign--;
        }

    }
    public void ChangeInfoLevel()
    {
        titulo.text = listaCampaign[indexCampaign].tituloNivel;
        nivel = listaCampaign[indexCampaign].nivelScene;
        imagenNivel.sprite = listaCampaign[indexCampaign].imagenNivel;
        //Reliquias
        if (!string.IsNullOrEmpty(listaCampaign[indexCampaign].idReliquia)) 
        {
            Debug.Log("Estoy Lleno");
            contornoReliquia.enabled = true;
            contornoReliquia.sprite = listaCampaign[indexCampaign].reliquiaContorno;
            if (listaCampaign[indexCampaign].onReliquia)
            {
                imagenReliquia.enabled = true;
                imagenReliquia.sprite = listaCampaign[indexCampaign].reliquiaImage;
            }
            else
            {
                imagenReliquia.enabled = false;
            }
        }
        else
        {

            Debug.Log("Estoy Vacio");
            contornoReliquia.enabled = false;
            imagenReliquia.enabled = false;
        }
    }
}
