using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextNoItem : MonoBehaviour
{
    public int indexMod;
    [Header("Texto")]
    [SerializeField] CanvasGroup text;
    [Header("Condiciones See Text")]
    [SerializeField] SoldierLife soldierVida;
    [Header("Item")]
    [SerializeField] CogerObjeto item;
    [Header("Time Text")]
    public float timeTextLimit;
    float timeText;

    bool showMeText;
    PlayerHere player;
    void Start()
    {
        player = GetComponent<PlayerHere>();
    }
    void Update()
    {
        //Muestra Texto
        MostrarTexto();
        //Al mostrar el texto desaparecera con el tiempo
        DisAppearText();
        //Condiciones para no ver el Texto
        NoMostrarText();
    }

    void MostrarTexto()
    {
        if (player.playerImHere && Input.GetKeyDown(KeyCode.T))
        {
            text.alpha = 1;
            timeText = 0;
            showMeText = true;
        }

    }
    void DisAppearText()
    {
        if (showMeText)
        {
            timeText += Time.deltaTime;
            if (timeText >= timeTextLimit)
            {
                showMeText = false;
            }
        }
        else
        {
            text.alpha -= 0.01f;
        }
    }
    void NoMostrarText()
    {
        if(soldierVida.vida < 1 || StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            //El item se activa
            item.enabled = true;
            //Desactivar texto
            this.enabled = false;
            text.alpha = 0;
            showMeText = false;
        }
    }
}
