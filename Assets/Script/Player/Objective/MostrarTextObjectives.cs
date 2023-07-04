using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class MostrarTextObjectives : MonoBehaviour
{
    public string fileName;
    public static int indexLine;
    [Header("New Note")]
    [SerializeField] Animator animNote;
    int linePrevious;
    [Header("Last Note")]
    public int indexLastNote;
    public GameObject checkComplete;
    [Header("Note Data")]
    public Text lines;
    public List<string> fileLine;

    Animator animObjective;
    bool objective;
    private void Awake()
    {
        animObjective = GetComponent<Animator>();
    }
    private void Start()
    {
        linePrevious = indexLine;

        string readFromFilePath = Application.dataPath + "/Textos/Text_Objective/" + fileName + ".txt";
        fileLine = File.ReadAllLines(readFromFilePath).ToList();
        lines.text = fileLine[indexLine];
    }
    private void Update()
    {
        ObjectiveTask();
        ObjectiveMostrar();
        LimitTask();
        NewNote();
        Check();

        lines.text = fileLine[indexLine];
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
    void LimitTask()
    {
        if(indexLine >= fileLine.Count)
        {
            indexLine = fileLine.Count - 1;
        }
    }

    void NewNote()
    {
        if(indexLine != linePrevious)
        {
            animNote.SetTrigger("NewNote");
            linePrevious = indexLine;
        }
    }

    void Check()
    {
        if(indexLine == fileLine.Count - 1)
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[indexLastNote].modificacion)
            {
                checkComplete.SetActive(true);
            }
        }
    }
}