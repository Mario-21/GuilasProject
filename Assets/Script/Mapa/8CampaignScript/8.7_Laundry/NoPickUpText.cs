using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoPickUpText : MonoBehaviour
{
    [Header("Text No Pick")]
    public CanvasGroup text;
    [Header("Conditions See Text")]
    [SerializeField] SoldierLife soldadoLaundry;
    public int indexAllergy;
    public int indexBath;

    PlayerHere player;

    float timeSeeText;
    bool seeText;
    void Start()
    {
        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        OutText();
        ConditionsText();
        TextHide();

        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                timeSeeText = 0;
                seeText = true;
            }
        }
    }
    void ConditionsText()
    {
        if (soldadoLaundry.vida > 0
            && !StatusGameobjectsVariables.statusGameobject.modificacion[indexAllergy].modificacion
            && !StatusGameobjectsVariables.statusGameobject.modificacion[indexBath].modificacion)
        {
            TextSee();
        }
    }
    void TextSee()
    {
        if (seeText)
        {
            text.alpha = 1;
        }
        else
        {
            text.alpha -= 0.01f;
        }
    }
    void TextHide() 
    {
        if (seeText)
        {
            timeSeeText += Time.deltaTime;
            if(timeSeeText >= 5)
            {
                seeText = false;
                timeSeeText = 0;
            }
        }
    }
    void OutText()
    {
        if (soldadoLaundry.vida <= 0
            || StatusGameobjectsVariables.statusGameobject.modificacion[indexAllergy].modificacion
            || StatusGameobjectsVariables.statusGameobject.modificacion[indexBath].modificacion)
        {
            this.enabled = false;
            text.alpha = 0f;

        }
    }
}
