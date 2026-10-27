using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarCondition : MonoBehaviour
{
    public int indexModJar;
    [SerializeField] CogerObjeto jarra;
    //[SerializeField] GameObject jarraVacia;
    void Start()
    {
        //You need time to execute this before the original script that made the gameObject disappear
        Invoke("JarConditionCheck", 0.2f);
    }
    void JarConditionCheck()
    {
        if (SaveScene.instancia.listaItemsNivelGuardar[indexModJar].objetoObtenido)
        {
            jarra.enabled = false;
            jarra.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
