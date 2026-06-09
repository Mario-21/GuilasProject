using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class ObjetosUIRuta : MonoBehaviour
{


    [SerializeField] int idObjeto;

    public Text textoObjeto;

    public bool activarComparacion;
    [Header("Ruta Española")]
    public string rutaEspañolaObjetos;
    public string nombreObjetoEspañol;
    public List<string> objetosEspañol;
    int indexEspañol = 1;
    [Header("Ruta Inglesa")]
    public string rutaInglesaObjetos;
    public string nombreObjetoIngles;
    public List<string> objetosIngles;
    int indexIngles = 1;
    void Start()
    {
        //Determinar 
        TamañoID(idObjeto);

        //Español
        //string readFromFilePathEspañol = Application.dataPath + "/Idiomas/Español/Objetos/" + rutaEspañolaObjetos + ".txt";
        objetosEspañol = File.ReadAllLines(IdiomaGlobalManager.readFromFilePathEspañolCompleto).ToList();
        CheckearListaObjetos(idObjeto,ref nombreObjetoEspañol, objetosEspañol, textoObjeto,indexEspañol);
        //nombreObjetoEspañol = objetosEspañol[idObjeto].Substring(indexEspañol + 1);

        //Ingles
        //string readFromFilePathIngles = Application.dataPath + "/Idiomas/Ingles/Items/" + rutaInglesaObjetos + ".txt";
        objetosIngles = File.ReadAllLines(IdiomaGlobalManager.readFromFilePathInglesComplete).ToList();
        CheckearListaObjetos(idObjeto,ref nombreObjetoIngles, objetosIngles, textoObjeto,indexIngles);
        //nombreObjetoIngles = objetosIngles[idObjeto].Substring(indexIngles + 1);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("El subString del elemento " + idObjeto + " " + objetosEspañol[idObjeto].Substring(0,1));
        //pruebaTexto = objetosEspañol[0].Substring(2, 7);
        switch (IdiomaGlobalManager.instanciaIdioma.idiomaActual)
        {
            case "Español":
                EscribirObjetoTexto(nombreObjetoEspañol, textoObjeto);
                break;
            case "English":
                EscribirObjetoTexto(nombreObjetoIngles, textoObjeto);
                break;
        }
    }
    public void CheckearListaObjetos(int id, ref string nombre, List<string> listaObjetos, Text textoPrincipalObjeto, int index)
    {
        
        for (int i = 0; i < listaObjetos.Count;i++)
        {
            if (id.ToString() == listaObjetos[i].Substring(0,index))
            {
                Debug.Log("Objeto encontrado en la lista " + listaObjetos[i]);
                textoPrincipalObjeto.text = listaObjetos[i].Substring(index + 1);
                nombre = textoPrincipalObjeto.text;
                listaObjetos.Clear();
                break;
            }
            else
            {
                Debug.Log("Soy el objeto en lista " + listaObjetos[i] + " y no coincido con el id del objeto seleccionado");
            }
        }
    }
    public void TamañoID(int id)
    {
        switch (id.ToString().Length)
        {
            case 1:
                //No hagas nada
                break;
            case 2:
                //Cuando hay dos digitos.
                indexEspañol++;
                indexIngles++;
                break;
            case 3:
                //Cuando son 3 digitos:
                indexEspañol += 2;
                indexIngles += 2;
                break;
        }
    }
    public void EncontrarObjetoId(int id, Text textoPrincipalObjeto,List<string> listaObjetos, int index)
    {
        textoPrincipalObjeto.text = listaObjetos[id].Substring(index + 1);
    }
    public void EscribirObjetoTexto(string nombre, Text textoPrincipalObjeto)
    {
        textoPrincipalObjeto.text = nombre;
    }
}
