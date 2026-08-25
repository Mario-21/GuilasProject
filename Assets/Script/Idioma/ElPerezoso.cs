using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
public class ElPerezoso : MonoBehaviour
{ 
    [SerializeField] int sizePantallaCarga;
    public string dataFileName;

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
    [ContextMenu("Crea Automaticamente los archivos txt de los tutoriales")]
    void CrearArchivosTutorialesAuto()
    {
        for (int i = 1; i < sizePantallaCarga; i++)
        {
            string pantallaCargaCompletaEspañol = "Tutorial_" + i + ".txt";
            string rutaSpanishPantallaCarga = Application.dataPath + "/Idiomas/Español/Tutoriales/";
            CrearArchivosTextoAuto(rutaSpanishPantallaCarga, pantallaCargaCompletaEspañol, i);
            Debug.Log(pantallaCargaCompletaEspañol);
            string pantallaCargaCompletaEnglish = "Tutorial_" + i + ".txt";
            string rutaEnglishLoadScreen = Application.dataPath + "/Idiomas/Ingles/Tutorials/";
            CrearArchivosTextoAuto(rutaEnglishLoadScreen, pantallaCargaCompletaEnglish, i);
            Debug.Log(pantallaCargaCompletaEnglish);
        }
    }
    [ContextMenu("Crea Automaticamente los archivos txt de los Reliquias")]
    void CrearArchivosReliquiasAuto()
    {
        for (int i = 1; i < sizePantallaCarga; i++)
        {
            string pantallaCargaCompletaEspañol = "Reliquia_" + i + ".txt";
            string rutaSpanishPantallaCarga = Application.dataPath + "/Idiomas/Español/Reliquias/";
            CrearArchivosTextoAuto(rutaSpanishPantallaCarga, pantallaCargaCompletaEspañol, i);
            Debug.Log(pantallaCargaCompletaEspañol);
            string pantallaCargaCompletaEnglish = "Relic_" + i + ".txt";
            string rutaEnglishLoadScreen = Application.dataPath + "/Idiomas/Ingles/Relics/";
            CrearArchivosTextoAuto(rutaEnglishLoadScreen, pantallaCargaCompletaEnglish, i);
            Debug.Log(pantallaCargaCompletaEnglish);
        }
    }
    void ArchivoInterfaceData(InterfaceText interfaceText, string nombreData)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, nombreData);
        try
        {
            //Crea un archivo en el directorio asignado si no hay uno existente
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //Transforma C# gamedata objeto en Json
            string dataToStore = JsonUtility.ToJson(interfaceText, true);

            //Escribe los datos serializados en el archivo
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }

            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error al intentar al intentar guardar el archivo" + fullPath + "\n" + e);
        }
    }
    [ContextMenu("Crea un InterfaceText.data")]
    void CrearArchivoInterfaceData()
    {
        InterfaceText interfaceTexto = new InterfaceText();
        ArchivoInterfaceData(interfaceTexto, dataFileName);

    }
    [ContextMenu("Guardar un InterfaceText.data")]
    void GuardarArchivoInterfaceData()
    {
        ArchivoInterfaceData(DataPersistenceManager.instance.interfaceDataText, dataFileName);
    }
    [ContextMenu("Cargar un InterfaceText.data")]
    void CargarArchivoInterFace()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, dataFileName);
        DataPersistenceManager.instance.interfaceDataText = null;
        //Revisa si existe un archivo que cargar
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToStore = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToStore = reader.ReadToEnd();
                    }

                }
                //Deserealizar los datos del archivo en json para pasar a un objeto en C#
                DataPersistenceManager.instance.interfaceDataText = JsonUtility.FromJson<InterfaceText>(dataToStore);
            }
            catch (Exception e)
            {
                Debug.LogError("Error al cargar los archivos desde: " + fullPath + "\n" + e);
            }
        }
    }

    //Este es el antiguo script de desencriptar la lista de objetos que se encontraba en el IdiomaGlobalManager
    void DesencriptaObjetos(string path, string nameArchivo, List<string> listObjetos)
    {
        string fullPath = Path.Combine(path, nameArchivo);

        if (File.Exists(fullPath))
        {
            Debug.Log("Existo,por tanto, no tengo que hacer nada");
            File.WriteAllText(fullPath, FileDataHandler.EncryptDecrypt(File.ReadAllText(fullPath)));
        }
        else
        {
            try
            {
                Debug.Log("Soy el " + path + " y estoy siendo creado");
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        for (int e = 0; e < listObjetos.Count; e++)
                        {
                            writer.WriteLine(listObjetos[e]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error al intentar crear el archivo" + fullPath + "\n" + e);
            }
        }
    }

}
