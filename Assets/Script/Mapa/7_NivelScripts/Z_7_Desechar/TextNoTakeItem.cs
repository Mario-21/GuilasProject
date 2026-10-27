using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextNoTakeItem : MonoBehaviour
{
    [Header("Conditions See Text")]
    public int indexSleep;
    [SerializeField] PutGasMask basketMask;
    [SerializeField] SoldierLife diarySoldier;
    [SerializeField] CanvasGroup text;

    float timeText;
    PlayerHere player;
    bool showT;
    void Start()
    {
        //Cuando presiones el boton de accion con las condiciones requeridas incumplidas, aparecera un Cambio de Area, esta te echara de la zona a la vez que reproduce un audio del soldado y levanta la mano
        //acusandote.
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexSleep].modificacion) this.enabled = false;
    }
    void Update()
    {
        ShowText();
        NoSeeText();
    }
    void ShowText()
    {
        if(!basketMask.putMask && diarySoldier.vida >= 1)
        {
            if (player.playerImHere && Input.GetButtonDown("Take"))
            {
                text.alpha = 1;
                timeText = 0;
                showT = true;
            }
        }
    }
    void NoSeeText()
    {
        if (showT)
        {
            timeText += Time.deltaTime;
            if(timeText >= 5)
            {
                showT = false;
            }
        }
        else
        {
            text.alpha -= 0.01f;
        }
    }
}
