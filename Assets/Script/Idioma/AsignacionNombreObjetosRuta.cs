using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class AsignacionNombreObjetosRuta : MonoBehaviour
{
    public List<InformacionObjetosID> objetosNivel;

    //Datos Español
    List<string> listaObjetosEspañol;
    //Datos Ingles
    List<string> listItemsEnglish;

    public int indexIdInicial = 36;
    public int indexIdObjeto = 37;

    private void Awake()
    {

    }
    void Start()
    {
        //Debug.Log("Soy el el objeto " + objetosNivel[0].nombreObjeto + " y el tamaño de mi id es " + listaObjetosEspañol[0].Substring(0, indexIdInicial));

        //objetoRevisarDebug = Random.Range(0, 76);

        listaObjetosEspañol = File.ReadAllLines(IdiomaGlobalManager.readFromFilePathEspañolCompleto).ToList();
        listItemsEnglish = File.ReadAllLines(IdiomaGlobalManager.readFromFilePathInglesComplete).ToList();

        //Debug.Log("Soy el el objeto /*+ objetosNivel[objetoRevisarDebug].nombreObjeto + */ y el tamaño de mi id es " + listaObjetosEspañol[objetoRevisarDebug].Substring(0, indexIdInicial) + "mi nombre en el idioma español es " + listaObjetosEspañol[objetoRevisarDebug].Substring(indexIdObjeto));

        
        while (objetosNivel.Count > 0)
        {
            CheckearListaObjetos(objetosNivel[0].idObjeto, ref SaveScene.instancia.listaItemsNivelGuardar[objetosNivel[0].idListaNivelObjetos].nombreObjetoEspañol, listaObjetosEspañol);
            CheckearListaObjetos(objetosNivel[0].idObjeto, ref SaveScene.instancia.listaItemsNivelGuardar[objetosNivel[0].idListaNivelObjetos].nombreObjetoIngles, listItemsEnglish);
            objetosNivel.RemoveAt(0);
        }


    }

    private void Update()
    {
        /*
        if (probarInformacionAsig)
        {
            for (int i = 0; i < objetosNivel.Count; i++)
            {
                TamañoID(objetosNivel[i].idObjeto);
                CheckearListaObjetos(objetosNivel[i].idObjeto, ref SaveScene.instancia.listaItemsNivelGuardar[objetosNivel[i].idListaNivelObjetos].nombreObjetoEspañol, listaObjetosEspañol, indexLetrasEspañol);
                CheckearListaObjetos(objetosNivel[i].idObjeto, ref SaveScene.instancia.listaItemsNivelGuardar[objetosNivel[i].idListaNivelObjetos].nombreObjetoIngles, listItemsEnglish, indexLetrasIngles);
                objetosNivel.RemoveAt(i);
                indexLetrasEspañol = 1;
                indexLetrasIngles = 1;

            }
        }*/
    }
    public void CheckearListaObjetos(string IDObjetoListaNivel, ref string nombre, List<string> listaObjetosIdiomas)
    {
        for (int e = 0; e < listaObjetosIdiomas.Count; e++)
        {
            if (IDObjetoListaNivel == listaObjetosIdiomas[e].Substring(0, indexIdInicial)) //IDObjetoListaNivel.Substring(0, indexIdInicial)
            {
                //Asigna el nombre dentro de la lista de objetos de nivel
                nombre = listaObjetosIdiomas[e].Substring(indexIdObjeto);
                return;
            }
        }
    }

    [ContextMenu("Te da un objeto random de la lista")]
    public void DameObjetosRandom()
    {
        int objetoRevisarDebug = Random.Range(0, 76);
        List<string> listaRandom = new List<string>();
        listaRandom = File.ReadAllLines(Application.dataPath + "/Idiomas/Español/Objetos/Lista_Objetos.txt").ToList();
        Debug.Log("Soy el el objeto " + listaRandom[objetoRevisarDebug].Substring(indexIdObjeto) + " y el tamaño de mi id es " + listaRandom[objetoRevisarDebug].Substring(0, indexIdInicial));
    }
}
[System.Serializable]
public class InformacionObjetosID
{
    public string nombreObjeto;
    public string idObjeto;
    public int idListaNivelObjetos;

}
