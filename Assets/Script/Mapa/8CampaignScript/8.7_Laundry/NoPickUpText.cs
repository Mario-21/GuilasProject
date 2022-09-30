using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoPickUpText : MonoBehaviour
{
    public CanvasGroup text;
    public bool seeText;

    [Header("Conditions See Text")]
    [SerializeField] SoldierLife soldadoLaundry;
    public int indexAllergy;
    public int indexBath;

    PlayerHere player;
    void Start()
    {
        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        OutText();
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                ConditionsText();
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
