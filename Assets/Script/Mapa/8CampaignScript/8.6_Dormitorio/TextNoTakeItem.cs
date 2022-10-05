using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextNoTakeItem : MonoBehaviour
{
    float timeText;
    [SerializeField] PutGasMask basketMask;
    [SerializeField] SoldierLife diarySoldier;
    [SerializeField] CanvasGroup text;

    PlayerHere player;
    bool showT;
    void Start()
    {
        player = GetComponent<PlayerHere>();
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
            if (player.playerImHere && Input.GetKeyDown(KeyCode.T))
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
