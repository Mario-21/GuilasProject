using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nombre_Item : MonoBehaviour
{
    public string nombre_Item;
    public Text nombre_Item_Text;

    public void Escribir_Nombre()
    {
        nombre_Item_Text.text = nombre_Item;
    }

    
    
}
