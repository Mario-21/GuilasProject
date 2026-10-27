using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CodigoDestornillador : MonoBehaviour
{
    public int indexMod;

    public string codigoDestornillador;
    public string writeCodigoDestornillador;

    public GameObject destornillador;

    [SerializeField] EventReference sonidoCaerDestor;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            destornillador.SetActive(true);
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        VerifiedCodeDestornillador();
        CleanCodeDestornillador();
    }
    void VerifiedCodeDestornillador()
    {
        //Si aciertas con la contraseña
        if(codigoDestornillador == writeCodigoDestornillador)
        {
            //Reproduce sonido característico para saber que lo has conseguido
            AudioManager.instancia.PlayOneShot(sonidoCaerDestor);
            //Aparece el destornillador
            destornillador.SetActive(true);
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            //Desactiva el script
            this.enabled = false;
        }
    }
    void CleanCodeDestornillador()
    {
        if(writeCodigoDestornillador.Length > codigoDestornillador.Length)
        {
            writeCodigoDestornillador = "";
        }
    }
}
