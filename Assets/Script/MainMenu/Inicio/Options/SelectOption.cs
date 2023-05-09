using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOption : MonoBehaviour
{
    public GameObject flechaSelect;


    public void MostrarFlecha()
    {
        flechaSelect.SetActive(true);
    }
    public void OcultarFlecha()
    {
        flechaSelect.SetActive(false);
    }
}
