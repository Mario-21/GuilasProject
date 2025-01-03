using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear_Nombre_Item : MonoBehaviour
{
    Text text_NombreItem;
    private void Awake()
    {
        text_NombreItem = GetComponent<Text>();
    }
    private void OnDisable()
    {
        text_NombreItem.text = "";
    }
}
