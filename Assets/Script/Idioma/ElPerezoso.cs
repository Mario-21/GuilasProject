using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class ElPerezoso : MonoBehaviour
{ 
    [SerializeField] int sizePantallaCarga;


    void EscribirListaDataObjetosTodosIdiomasAuto()
    {
        //ListaDataObjetosTodosIdiomas listaDataTodosObjetos = new ListaDataObjetosTodosIdiomas();

        for (int i = 0; i < DataPersistenceManager.instance.listItemLanguage.listAllItemsEnglish.Count; i++)
        {
            //Crea los parametros en vacio para que no te repita el mismo valor
            ListaDataObjetosTodosIdiomas listaDataTodosObjetos = new ListaDataObjetosTodosIdiomas();
            IdiomasItems idiomasItems = new IdiomasItems();

            //Establece la Id del objeto
            listaDataTodosObjetos.idObjeto = DataPersistenceManager.instance.listItemLanguage.listAllItemsEnglish[i].Substring(0, 36);
            //EStablece los nombres en uss respectivos idiomas
            idiomasItems.spanish = DataPersistenceManager.instance.listItemLanguage.listaTodosObjetosEspañol[i].Substring(37);
            idiomasItems.english = DataPersistenceManager.instance.listItemLanguage.listAllItemsEnglish[i].Substring(37);

            listaDataTodosObjetos.nombresObjetosIdiomas = idiomasItems;
            //listaDataTodosObjetos.nombresObjetosIdiomas.english = "Ingles"; //DataPersistenceManager.instance.listItemLanguage.listAllItemsEnglish[i].Substring(37);


            DataPersistenceManager.instance.listItemLanguage.listaDataObjetosTodosIdiomas.Add(listaDataTodosObjetos);

        }
    }
    void CrearArchivosTextoAuto(string rutaAchivo, string nombreArchivo, int numeroPantallaCarga)
    {
        string fullPath = Path.Combine(rutaAchivo, nombreArchivo);
        if (File.Exists(fullPath))
        {
            Debug.Log("Existo, la pereza ha ganado");
        }
        else
        {
            try
            {
                Debug.Log("Me crearon con exito, soy " + nombreArchivo);
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.WriteLine("Soy " + nombreArchivo);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error al intentar crear el archivo" + fullPath + "\n" + e);
            }
        }
    }
    [ContextMenu("Crea Automaticamente los archivos txt de las pantallas de carga")]
    void CrearArchivosPantallasCargaAuto()
    {
        for(int i = 1; i < sizePantallaCarga; i++)
        {
            string pantallaCargaCompletaEspañol = "Pantalla_" + i + ".txt";
            string rutaSpanishPantallaCarga = Application.dataPath + "/Idiomas/Español/Pantalla_Carga/";
            CrearArchivosTextoAuto(rutaSpanishPantallaCarga, pantallaCargaCompletaEspañol, i);
            Debug.Log(pantallaCargaCompletaEspañol);
            string pantallaCargaCompletaEnglish = "Screen_" + i + ".txt";
            string rutaEnglishLoadScreen = Application.dataPath + "/Idiomas/Ingles/LoadScreen/";
            CrearArchivosTextoAuto(rutaEnglishLoadScreen, pantallaCargaCompletaEnglish, i);
            Debug.Log(pantallaCargaCompletaEnglish);
        }
    }
    [ContextMenu("Crea Automaticamente un archivo individual")]
    void CrearArchivosIndividuales()
    {
        //CrearArchivosTextoAuto(rutaSpanishPantallaCarga, pantallaCargaCompletaEspañol, i);
    }
    [ContextMenu("Crea Automaticamente los archivos txt de los objetivos")]
    void CrearArchivosObjetivosAuto()
    {
        for (int i = 1; i < sizePantallaCarga; i++)
        {
            string pantallaCargaCompletaEspañol = "Objetivos_" + i + ".txt";
            string rutaSpanishPantallaCarga = Application.dataPath + "/Idiomas/Español/Objetivos/";
            CrearArchivosTextoAuto(rutaSpanishPantallaCarga, pantallaCargaCompletaEspañol, i);
            Debug.Log(pantallaCargaCompletaEspañol);
            string pantallaCargaCompletaEnglish = "Objectives_" + i + ".txt";
            string rutaEnglishLoadScreen = Application.dataPath + "/Idiomas/Ingles/Objectives/";
            CrearArchivosTextoAuto(rutaEnglishLoadScreen, pantallaCargaCompletaEnglish, i);
            Debug.Log(pantallaCargaCompletaEnglish);
        }
    }
}
