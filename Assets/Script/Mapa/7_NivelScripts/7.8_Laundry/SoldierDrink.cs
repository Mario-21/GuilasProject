using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDrink : MonoBehaviour
{
    public int indexModAllergy;
    public int indexModPee;
    [Header ("Drink Info")]
    [SerializeField] LiquidColor liquid;
    [SerializeField] int drinkAllergy;
    [Header("Soldier Info")]
    [SerializeField] SoldierLife laundrySoldierLife;
    [SerializeField] SoldadoNormal laundrySoldado;

    int totalBebidas;
    int bebidasCons;
    int numConsum;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //probar con el activadorModificador, pero aumentando sus usos al usar la otra bebidda
        //Tomar de referencia la pala
    }
    void Allergy()
    {
        //COndiciones: Si el soldado esta vivo y es pasivo. Además de yo 

        //Nota: El trigger tiene que seguir le, pero sin ser hijo de. además de el tio tener que estar pasivo
        if(liquid.selectedDrink == drinkAllergy)
        {
            //Mata al Soldado, apaga el boton del vaso, activa el modificador
        }
        else
        {
            //Incrementa el limite de ambos vasos, apaga el vaso lleno y incrementa en 1 al numero de bebidas ingeridas. Cuando llegue a 3 activara el otro mod
        }
    }
}
