using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveLiquid : MonoBehaviour
{
    public int selectedDrinkStart;
    public int consumptionStart;
    void Start()
    {
        selectedDrinkStart = LiquidColor.liquid.selectedDrink;
        consumptionStart = LiquidColor.liquid.consumption;
    }
    public void LiquidRevivir()
    {
        LiquidColor.liquid.selectedDrink = selectedDrinkStart;
        LiquidColor.liquid.consumption = consumptionStart;
    }
}
