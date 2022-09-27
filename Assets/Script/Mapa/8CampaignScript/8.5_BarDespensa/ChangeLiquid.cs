using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLiquid : MonoBehaviour
{
    public string cupFullTag;
    public string cupEmptyTag;
    [SerializeField] LiquidColor colorLiquid;
    public int typeDrink;

    bool cup;
    bool player;

    void Update()
    {
        //You can change you drink
        if(cup && player)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Liquid Change");
                colorLiquid.selectedDrink = typeDrink;
                SaveScene.instancia.drink = typeDrink;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Jarra vacia o llena
        if (collision.gameObject.CompareTag(cupFullTag) || collision.gameObject.CompareTag(cupEmptyTag)) cup = true;
        if (collision.gameObject.CompareTag("Player")) player = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(cupFullTag) || collision.gameObject.CompareTag(cupEmptyTag)) cup = true;
        if (collision.gameObject.CompareTag("Player")) player = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(cupFullTag) || collision.gameObject.CompareTag(cupEmptyTag)) cup = false;
        if (collision.gameObject.CompareTag("Player")) player = false;
    }
}
