using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidColor : MonoBehaviour
{
    public int selectedDrink;

    private void Start()
    {
        //Establece el tipo de bebida que has seleccionado
        selectedDrink = SaveScene.instancia.drink;
    }
}
