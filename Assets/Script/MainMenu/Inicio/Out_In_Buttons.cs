using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Out_In_Buttons : MonoBehaviour
{
    [Header("Botones que Aparecen")]
    public List<GameObject> buttonsAppear;
    [Header("Botones que Desaparecen")]
    public List<GameObject> buttonsDisAppear;

    //Al presionar el boton, algunos botones aparecen y desaparecen
    public void ButtonsFuncion()
    {
        Show_Delete_Items buttons = new Show_Delete_Items();

        //Aparecen los botones
        buttons.ShowItems(buttonsAppear);
        buttons.DeleteItems(buttonsDisAppear);
        
    }
    
}
