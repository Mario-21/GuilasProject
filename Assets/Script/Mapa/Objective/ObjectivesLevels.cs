using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ObjectivesLevels : MonoBehaviour
{
    public static ObjectivesLevels instanceObjectivesLevel;

    public int indexLine;

    [Header("Nombres Objetivos Archivos")]
    public string fileNameSpanish;
    public string fileNameEnglish;

    [Header("Listas Objetivos Idiomas")]
    public List<string> objectiveSpanish;
    public List<string> objectiveEnglish;

    private void Awake()
    {
        if (ObjectivesLevels.instanceObjectivesLevel == null)
        {
            ObjectivesLevels.instanceObjectivesLevel = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        indexLine = 0;
        string readFromFilePathEspañol = Application.dataPath + "/Idiomas/Español/Objetivos/" + fileNameSpanish + ".txt";
        objectiveSpanish = File.ReadAllLines(readFromFilePathEspañol).ToList();

        string readFromLinePathEnglish = Application.dataPath + "/Idiomas/Ingles/Objectives/" + fileNameEnglish + ".txt";
        objectiveEnglish = File.ReadAllLines(readFromLinePathEnglish).ToList();
    }
    public void TaskObjectiveComplete(int taskWho)
    {
        if (indexLine == taskWho)
        {
            indexLine++;
        }
    }
}
