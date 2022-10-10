using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaundryTextHelp : MonoBehaviour
{
    public int indexMod;

    [SerializeField] CanvasGroup laundryText;
    [SerializeField] CanvasGroup soldierText;

    float timeSeeText;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }
    void Update()
    {
        LaundryText();
    }
    void LaundryText()
    {
        if(timeSeeText < 2)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            timeSeeText += Time.deltaTime;
            laundryText.alpha = 1;
            soldierText.alpha = 0;
        }
        else
        {
            laundryText.alpha -= 0.01f;
        }
    }
}
