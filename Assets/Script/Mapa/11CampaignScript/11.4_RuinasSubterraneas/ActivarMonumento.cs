using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMonumento : MonoBehaviour
{
    public int indexMod;
    ActivarModificador activador;
    [Header("Reliquia")]
    [SerializeField] Rigidbody2D rbReliquia;
    [Header("Pupila Guilla")]
    [SerializeField] GameObject pupilaGuilla;
    [Header("Boca Guilla")]
    [SerializeField] GameObject bocaCerrada;
    [SerializeField] GameObject bocaAbierta;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) OpenGuillaMouth();
    }

    // Update is called once per frame
    void Update()
    {
        if (activador.modificacion) OpenGuillaMouth();
    }
    void OpenGuillaMouth()
    {
        //Variable
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        //Reliquia 
        rbReliquia.bodyType = RigidbodyType2D.Dynamic;
        //Colocar Ojo
        pupilaGuilla.SetActive(true);
        //Abrir Boca
        bocaAbierta.SetActive(true);
        bocaCerrada.SetActive(false);
        //Desactivar para que funcione el revivir
        activador.enabled = false;
        this.enabled = false;

    }
}
