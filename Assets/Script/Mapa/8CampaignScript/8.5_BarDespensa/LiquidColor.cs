using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidColor : MonoBehaviour
{
    public static LiquidColor liquid;

    public int selectedDrink;
    public int consumption;
    private void Awake()
    {
        //Creo que no voy a colocar el revivir, dado que solo funcionaria en la misma zona de la despensa y debes de para ello morir, no renta nada 
        if(LiquidColor.liquid == null)
        {
            LiquidColor.liquid = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //Establece el tipo de bebida que has seleccionado
        //selectedDrink = drink;
    }
}
