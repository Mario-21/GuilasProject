using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorListasNivel : MonoBehaviour
{
    //O hacer una instancia o el nombre statico

    public string nombreSiguienteNivel; 
    public int indexLista;

    public List<InformacionNivel> infoNiveles;
    void Start()
    {
        for(int i = 0; i < infoNiveles.Count; i++)
        {
            if(infoNiveles[i].nivelNombre == nombreSiguienteNivel)
            {
                indexLista = i;
                EstructuraNiveles.nivel = infoNiveles[i].nivelIndex;
                StartCoroutine(SpawneoListaObjetosNivel(infoNiveles, indexLista));
                break;
            }
        }
    }
    IEnumerator SpawneoListaObjetosNivel(List<InformacionNivel> listaInfoNiveles, int indexLista)
    {
        Instantiate(infoNiveles[indexLista].saveDataNivel);
        yield return new WaitForSeconds(0.2f);
        Instantiate(infoNiveles[indexLista].asignacionNombreObjetoNivel);
    }
}
public class InformacionNivel
{
    public string nivelNombre;
    public int nivelIndex;

    public GameObject saveDataNivel;
    public GameObject asignacionNombreObjetoNivel;
}
