using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorListasNivel : MonoBehaviour
{
    //O hacer una instancia o el nombre statico

    public static string nombreSiguienteNivel;
    public string archivoNivelPantallaCarga;
    public GameObject asignacionObjetosDictionary;
    public GameObject asignacionDataPlayer;

    int indexListInfoNivel;
    public List<InfoNivel> informacionNiveles;
    void Start()
    {
        for(int i = 0; i < informacionNiveles.Count; i++)
        {
            if(informacionNiveles[i].nivelNombre == nombreSiguienteNivel)
            {
                indexListInfoNivel = i;
                ListaReliquias.instancia.numReliquiaNivel = informacionNiveles[i].numReliquia;
                //EscribirPantallaCargaNiveles es un mera referencia para acordarme de los datos que tengo que obtener
                //EscribirPantallaCargaNiveles.EscribirTextoStatic(idiomaSelecionado.ToString(), nameArchivo, textoUICarga, velocidadLetra, letraInvisible);
                EstructuraNiveles.nivel = informacionNiveles[i].scenaNivel;
                CheckPointController.numeroCheckPoint = informacionNiveles[i].spawnInicial;
                StartCoroutine(SpawneoListaObjetosNivel(informacionNiveles));
                switch (IdiomaGlobalManager.instanciaIdioma.idiomaActual)
                {
                    case "Español":
                        archivoNivelPantallaCarga = informacionNiveles[i].archiveSpanish;
                        break;
                    case "English":
                        archivoNivelPantallaCarga = informacionNiveles[i].archiveEnglish;
                        break;
                }
                break;
            }
        }
    }
    IEnumerator SpawneoListaObjetosNivel(List<InfoNivel> listaInfoNivel)
    {
        Instantiate(asignacionDataPlayer);
        Instantiate(listaInfoNivel[indexListInfoNivel].listaObjetosNivel);
        Instantiate(listaInfoNivel[indexListInfoNivel].listaObjectives);
        yield return new WaitForSeconds(0.2f);
        Instantiate(asignacionObjetosDictionary);
    }
}
[System.Serializable]
public class InfoNivel
{
    [Header("Nombre Nivel")]
    public string nivelNombre;
    [Header("Index Escena Nivel")]
    public int scenaNivel;
    public int spawnInicial;
    [Header("Numero de la Reliquia en Nivel")]
    public int numReliquia;
    [Header("Nombre Archivos Pantallas Carga")]
    public string archiveSpanish;
    public string archiveEnglish;
    [Header("Lista Objetivos")]
    public GameObject listaObjectives;
    [Header("Lista Objetos Nivel")]
    public GameObject listaObjetosNivel;
}
