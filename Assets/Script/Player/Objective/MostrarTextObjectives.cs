using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class MostrarTextObjectives : MonoBehaviour
{
    [Header("New Note")]
    [SerializeField] Animator animNote;
    int linePrevious;
    [Header("Last Note")]
    //realmente puede quitarla dado que este solo estaba cuando completabas la task final,
    //pero como la task final en todos los niveles es terminal del nivel, da igual el check que le pones al final
    public int indexLastNote;
    public GameObject checkComplete;
    [Header("Note Data")]
    public Text lines;
    Animator animObjective;
    bool objective;

    string idiomaGuardado;
    int actualizarIndex;
    private void Awake()
    {
        animObjective = GetComponent<Animator>();
    }
    private void Start()
    {
        //Esto sirve para tener una manera que al NewNote no quede en bucle escribiendo notas, es un limitante
        linePrevious = ObjectivesLevels.instanceObjectivesLevel.indexLine;

        //string readFromFilePath = Application.dataPath + "/Textos/Text_Objective/" + fileName + ".txt";
        //Debug.Log(readFromFilePath);
        //fileLineSpanish = File.ReadAllLines(readFromFilePath).ToList();
        /*
        string readFromFilePathEspañol = Application.dataPath + "/Idiomas/Español/Objetivos/" + fileName + ".txt";
        fileLineSpanish = File.ReadAllLines(readFromFilePathEspañol).ToList();
        //lines.text = fileLineSpanish[indexLine];

        string readFromLinePathEnglish = Application.dataPath + "/Idiomas/Ingles/Objectives/" + fileNameEnglish + ".txt";
        fileLineEnglish = File.ReadAllLines(readFromLinePathEnglish).ToList();
        */


        //lines.text = fileLineSpanish[indexLine];
    }
    private void Update()
    {
        //EstablecerIdiomaObjetivos();
        if(idiomaGuardado != IdiomaGlobalManager.instanciaIdioma.idiomaActual || actualizarIndex != ObjectivesLevels.instanceObjectivesLevel.indexLine)
        {
            EstablecerIdiomaObjetivo_2();
        }
        ObjectiveTask();
        ObjectiveMostrar();
        //LimitTask();
        NewNote();
        //Check();

        //lines.text = fileLineSpanish[indexLine];
    }
    void ObjectiveTask()
    {
        if (Input.GetButton("Task"))
        {
            Debug.Log("Objective On");
            objective = true;
        }
        else if (Input.GetButtonUp("Task"))
        {
            Debug.Log("Objective Off");
            objective = false;
        }
    }
    void ObjectiveMostrar()
    {
        if (objective)
        {
            animObjective.SetBool("OnObjective", true);
        }
        else
        {
            animObjective.SetBool("OnObjective", false);
        }
    }
    void EstablecerIdiomaObjetivos()
    {
        IdiomaGlobalManager.instanciaIdioma.SelectorTextoIdioma(ref idiomaGuardado, lines,
            ObjectivesLevels.instanceObjectivesLevel.objectiveSpanish[ObjectivesLevels.instanceObjectivesLevel.indexLine],
            ObjectivesLevels.instanceObjectivesLevel.objectiveEnglish[ObjectivesLevels.instanceObjectivesLevel.indexLine]);
    }
    void EstablecerIdiomaObjetivo_2()
    {
        if (DataPersistenceManager.instance.interfaceDataText.objectiveText.TryGetValue(IdiomaGlobalManager.instanciaIdioma.idiomaActual, out SerializableDictionary<string, string> secondDictionary))
        {
            if (secondDictionary.TryGetValue(ObjectivesLevels.instanceObjectivesLevel.idObjetivos + ObjectivesLevels.instanceObjectivesLevel.indexLine, out string resultadoTraducido))
            {
                lines.text = resultadoTraducido;
                idiomaGuardado = IdiomaGlobalManager.instanciaIdioma.idiomaActual;
                actualizarIndex = ObjectivesLevels.instanceObjectivesLevel.indexLine;
            }
        }
    }
    void LimitTask()
    {
        /*
        if(indexLine >= fileLineSpanish.Count)
        {
            indexLine = fileLineSpanish.Count - 1;
        }
        */
    }

    void NewNote()
    {
        if(ObjectivesLevels.instanceObjectivesLevel.indexLine != linePrevious)
        {
            animNote.SetTrigger("NewNote");
            linePrevious = ObjectivesLevels.instanceObjectivesLevel.indexLine;
        }
    }

    void Check()
    {
        /*
        if(indexLine == fileLineSpanish.Count - 1)
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[indexLastNote].modificacion)
            {
                checkComplete.SetActive(true);
            }
        }*/
    }
}