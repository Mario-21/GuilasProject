using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidConf : MonoBehaviour
{
    [SerializeField] List<Color> liquid;
    LiquidColor liquidColor;
    SpriteRenderer bebidaColor;
    void Start()
    {
        bebidaColor = GetComponent<SpriteRenderer>();
        liquidColor = FindObjectOfType<LiquidColor>();
    }

    // Update is called once per frame
    void Update()
    {
        DrinkType();
    }
    void DrinkType()
    {
        bebidaColor.color = liquid[liquidColor.selectedDrink];
    }
}
