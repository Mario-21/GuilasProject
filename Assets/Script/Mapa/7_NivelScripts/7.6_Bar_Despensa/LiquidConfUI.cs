using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidConfUI : MonoBehaviour
{
    Image liquidoColorUI;
    [SerializeField] Image vasoDown;
    [SerializeField] SaveButton buttonVaso;
    [SerializeField] List<Color> liquid;
    void Start()
    {
        liquidoColorUI = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        DrinkTypeUI();
        LimiteBebida();
    }
    void DrinkTypeUI()
    {
        liquidoColorUI.color = liquid[LiquidColor.liquid.selectedDrink];
    }
    void LimiteBebida()
    {
        if (buttonVaso.usos >= buttonVaso.usosLimitados)
        {
            liquidoColorUI.color = new Color(1f, 1f, 1f, 0.25f);
            vasoDown.color = new Color(1f, 1f, 1f, 0.25f);
        }
    }
}
