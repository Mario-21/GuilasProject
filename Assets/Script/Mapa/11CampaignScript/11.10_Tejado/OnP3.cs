using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnP3 : MonoBehaviour
{
    public int indexMod;
    [SerializeField] Image button;

    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ActiveP3();
        }   
    }
    public void ActiveP3()
    {
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        button.color = Color.green;
    }
}
