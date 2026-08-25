using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ExcribirMiniTextosData : MonoBehaviour
{

    [Header("Objetivos")]
    public int objetivoLimit;
    [Header("Plantemiento_1")]
    public string nombreIdiomaEstablecer;
    public string nombreIndividual;
    public string nombreTraduccionIndividual;
    public List<string> id_TextoPequeños;
    public List<string> nombre_TraduccionTextoPequeños;
    public List<string> name_TraductionSmallText;
    int tamañoTotalDictionary;
    int listAparte;

    [Header("Plantemiento_2")]
    public string nombreEspañol;
    public string nombreEnglish;
    public string nombreMainDictionary;

    public string idPrimerDictionary;
    public string idSegundoDictionary;

    

    [ContextMenu("Añadir SecondDictionary V1 General Español")]
    public void AddDictionarySecondV1Español()
    {
        SerializableDictionary<string, string> secondaryDictionary = new SerializableDictionary<string, string>();
        for (int i = 0; i < id_TextoPequeños.Count; i++)
        {
            secondaryDictionary.Add(id_TextoPequeños[i], nombre_TraduccionTextoPequeños[i]);
        }
        //GameDataNoDestroy.instance.gameData.textosMenores.Add(nombreIdiomaEstablecer, secondaryDictionary);
        DataPersistenceManager.instance.interfaceDataText.interfaceText.Add(nombreIdiomaEstablecer, secondaryDictionary);


    }
    [ContextMenu("Añadir SecondDictionary V1 Objetivos Español")]
    public void AddDictionarySecondV1ObjetivosEspañol()
    {
        SerializableDictionary<string, string> secondaryDictionary = new SerializableDictionary<string, string>();
        for (int i = 0; i < id_TextoPequeños.Count; i++)
        {
            secondaryDictionary.Add(id_TextoPequeños[i], nombre_TraduccionTextoPequeños[i]);
        }
        //GameDataNoDestroy.instance.gameData.textosMenores.Add(nombreIdiomaEstablecer, secondaryDictionary);
        DataPersistenceManager.instance.interfaceDataText.objectiveText.Add(nombreIdiomaEstablecer, secondaryDictionary);


    }
    [ContextMenu("Añadir SecondDictionary V1 Tuto Español")]
    public void AddDictionarySecondV1TutoEspañol()
    {
        SerializableDictionary<string, string> secondaryDictionary = new SerializableDictionary<string, string>();
        for (int i = 0; i < id_TextoPequeños.Count; i++)
        {
            secondaryDictionary.Add(id_TextoPequeños[i], nombre_TraduccionTextoPequeños[i]);
        }
        //GameDataNoDestroy.instance.gameData.textosMenores.Add(nombreIdiomaEstablecer, secondaryDictionary);
        DataPersistenceManager.instance.interfaceDataText.tutorialesText.Add(nombreIdiomaEstablecer, secondaryDictionary);


    }
    [ContextMenu("Añadir SecondDictionary V1 General English")]
    public void AddDictionarySecondV1English()
    {
        SerializableDictionary<string, string> secondaryDictionary = new SerializableDictionary<string, string>();
        for (int i = 0; i < id_TextoPequeños.Count; i++)
        {
            secondaryDictionary.Add(id_TextoPequeños[i], name_TraductionSmallText[i]);
        }
        //GameDataNoDestroy.instance.gameData.textosMenores.Add(nombreIdiomaEstablecer, secondaryDictionary);
        DataPersistenceManager.instance.interfaceDataText.interfaceText.Add(nombreIdiomaEstablecer, secondaryDictionary);
    }
    [ContextMenu("Añadir SecondDictionary V1 Objetivos English")]
    public void AddDictionarySecondV1ObjetivosEnglish()
    {
        SerializableDictionary<string, string> secondaryDictionary = new SerializableDictionary<string, string>();
        for (int i = 0; i < id_TextoPequeños.Count; i++)
        {
            secondaryDictionary.Add(id_TextoPequeños[i], name_TraductionSmallText[i]);
        }
        //GameDataNoDestroy.instance.gameData.textosMenores.Add(nombreIdiomaEstablecer, secondaryDictionary);
        DataPersistenceManager.instance.interfaceDataText.objectiveText.Add(nombreIdiomaEstablecer, secondaryDictionary);
    }
    [ContextMenu("Añadir SecondDictionary V1 Tuto English")]
    public void AddDictionarySecondV1TutoEnglish()
    {
        SerializableDictionary<string, string> secondaryDictionary = new SerializableDictionary<string, string>();
        for (int i = 0; i < id_TextoPequeños.Count; i++)
        {
            secondaryDictionary.Add(id_TextoPequeños[i], name_TraductionSmallText[i]);
        }
        //GameDataNoDestroy.instance.gameData.textosMenores.Add(nombreIdiomaEstablecer, secondaryDictionary);
        DataPersistenceManager.instance.interfaceDataText.tutorialesText.Add(nombreIdiomaEstablecer, secondaryDictionary);
    }
    [ContextMenu("Añadir SecondDictionary V1 un valor")]
    public void AddDictionarySecondV1TheOne()
    {
        //if (GameDataNoDestroy.instance.gameData.textosMenores.ContainsKey(nombreIdiomaEstablecer))
        if (DataPersistenceManager.instance.interfaceDataText.interfaceText.ContainsKey(nombreIdiomaEstablecer))
        {
            //GameDataNoDestroy.instance.gameData.textosMenores[nombreIdiomaEstablecer].Add(nombreIndividual, nombreTraduccionIndividual);
            DataPersistenceManager.instance.interfaceDataText.interfaceText[nombreIdiomaEstablecer].Add(nombreIndividual, nombreTraduccionIndividual);
        }
    }
    [ContextMenu("Añadir SecondDictionary V1 apartir de un numero concreto de la lista")]
    public void AddDictionarySecondV1ListAparte()
    {
        listAparte = 0;
        //tamañoTotalDictionary = GameDataNoDestroy.instance.gameData.textosMenores[nombreIdiomaEstablecer].Count + nombre_TextoPequeños.Count;
        tamañoTotalDictionary = DataPersistenceManager.instance.interfaceDataText.interfaceText[nombreIdiomaEstablecer].Count + id_TextoPequeños.Count;
        //for (int sizeDictionary = GameDataNoDestroy.instance.gameData.textosMenores[nombreIdiomaEstablecer].Count; sizeDictionary < tamañoTotalDictionary; sizeDictionary++)
        for (int sizeDictionary = DataPersistenceManager.instance.interfaceDataText.interfaceText[nombreIdiomaEstablecer].Count; sizeDictionary < tamañoTotalDictionary; sizeDictionary++)
        {
            //if (GameDataNoDestroy.instance.gameData.textosMenores.ContainsKey(nombreIdiomaEstablecer))
            if (DataPersistenceManager.instance.interfaceDataText.interfaceText.ContainsKey(nombreIdiomaEstablecer))
            {
                //GameDataNoDestroy.instance.gameData.textosMenores[nombreIdiomaEstablecer].Add(nombre_TextoPequeños[listAparte], nombre_TraduccionTextoPequeños[listAparte]);
                DataPersistenceManager.instance.interfaceDataText.interfaceText[nombreIdiomaEstablecer].Add(id_TextoPequeños[listAparte], nombre_TraduccionTextoPequeños[listAparte]);
                if (listAparte < id_TextoPequeños.Count) listAparte++;
            }
        }
    }
    [ContextMenu("Añadir SecondDictionary V1 sustituir valor")]
    public void SustituirSecondDictionaryV1()
    {

        //if (GameDataNoDestroy.instance.gameData.textosMenores.TryGetValue(nombreIdiomaEstablecer, out SerializableDictionary<string, string> segundoDictionary))
        if (DataPersistenceManager.instance.interfaceDataText.interfaceText.TryGetValue(nombreIdiomaEstablecer, out SerializableDictionary<string, string> segundoDictionary))
        {
            //Ahora ya se pueden ver las Keys
            if (segundoDictionary.ContainsKey(nombreIndividual))
            {
                segundoDictionary.Remove(nombreIndividual);
            }
            segundoDictionary.Add(nombreIndividual, nombreTraduccionIndividual);
        }
    }
    [ContextMenu("Escribir IDInterfaceText")]
    void EscribirIDInterfaceText()
    {
        id_TextoPequeños.Clear();
        nombre_TraduccionTextoPequeños.Clear();
        name_TraductionSmallText.Clear();

        string rutaIdTextos = Application.persistentDataPath + "/idminitextos.txt";
        string miniTextosSpanish = Application.persistentDataPath + "/ContenidoTextoMiniEspañol.txt";
        string miniTextosEnglish = Application.persistentDataPath + "/ContenidoTextoMiniEnglish.txt";
        id_TextoPequeños = File.ReadAllLines(rutaIdTextos).ToList();
        nombre_TraduccionTextoPequeños = File.ReadAllLines(miniTextosSpanish).ToList();
        name_TraductionSmallText = File.ReadAllLines(miniTextosEnglish).ToList();
    }
    [ContextMenu("Escribir IDObjetivosText")]
    void EscribirIDObjetivosText()
    {
        id_TextoPequeños.Clear();
        nombre_TraduccionTextoPequeños.Clear();
        name_TraductionSmallText.Clear();

        string rutaObjetivos = Application.dataPath + "/Idiomas/idobjetivosnivel.txt";
        id_TextoPequeños = File.ReadAllLines(rutaObjetivos).ToList();
        for (int i = 1; i < objetivoLimit; i++) 
        {
            string miniTextosSpanish = Application.dataPath + "/Idiomas/Español/Objetivos/Objetivos_" + i + ".txt";
            string miniTextosEnglish = Application.dataPath + "/Idiomas/Ingles/Objectives/Objectives_" + i + ".txt";

            List<string> listaTextosSpanish = new List<string>();
            listaTextosSpanish = File.ReadAllLines(miniTextosSpanish).ToList();

            List<string> listaTextosEnglish = new List<string>();
            listaTextosEnglish = File.ReadAllLines(miniTextosEnglish).ToList();

            for (int w = 0; w < listaTextosEnglish.Count; w++)
            {
                nombre_TraduccionTextoPequeños.Add(listaTextosSpanish[w]);
                name_TraductionSmallText.Add(listaTextosEnglish[w]);
            }
        }
    }
    [ContextMenu("Escribir IDTutosText")]
    void EscribirIDTutosText()
    {
        id_TextoPequeños.Clear();
        nombre_TraduccionTextoPequeños.Clear();
        name_TraductionSmallText.Clear();


        string rutaObjetivos = Application.dataPath + "/Idiomas/idtutorialestext.txt";
        id_TextoPequeños = File.ReadAllLines(rutaObjetivos).ToList();

        for (int i = 1; i < objetivoLimit; i++)
        {
            string miniTextosSpanish = Application.dataPath + "/Idiomas/Español/Tutoriales/TutoLeerDataSpanish/Tutorial_" + i + ".txt";
            string miniTextosEnglish = Application.dataPath + "/Idiomas/Ingles/Tutorials/TutoLeerDataEnglish/Tutorial_" + i + ".txt";

            string listaTextosSpanish;
            listaTextosSpanish = File.ReadAllText(miniTextosSpanish);

            nombre_TraduccionTextoPequeños.Add(listaTextosSpanish);

            string listaTextosEnglish;
            listaTextosEnglish = File.ReadAllText(miniTextosEnglish);

            name_TraductionSmallText.Add(listaTextosEnglish);

        }
    }
    [ContextMenu("Añadir SecondDictionary V2")]
    public void AddDictionarySecondV2()
    {

        SerializableDictionary<string, string> secondaryDictionary = new SerializableDictionary<string, string>();

        secondaryDictionary.Add("Español", nombreEspañol);
        secondaryDictionary.Add("English", nombreEnglish);

        //GameDataNoDestroy.instance.gameData.minusText.Add(nombreMainDictionary, secondaryDictionary);

    }
}
