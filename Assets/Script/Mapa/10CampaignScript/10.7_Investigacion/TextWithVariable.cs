using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWithVariable : MonoBehaviour
{
    [Header("Conditions See Text")]
    public int indexMod;
    [SerializeField] CanvasGroup text;

    float timeText;
    PlayerHere player;
    bool showT;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }
    void Update()
    {
        ShowText();
        NoSeeText();
    }
    void ShowText()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            if (player.playerImHere && Input.GetKeyDown(KeyCode.T))
            {
                text.alpha = 1;
                timeText = 0;
                showT = true;
            }
        }
        else
        {
            text.alpha = 0;
            this.enabled = false;
        }
        
    }
    void NoSeeText()
    {
        if (showT)
        {
            timeText += Time.deltaTime;
            if (timeText >= 5)
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
