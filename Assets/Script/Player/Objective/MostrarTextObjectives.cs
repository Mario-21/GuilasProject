using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class MostrarTextObjectives : MonoBehaviour
{
    public static string fileName;
    public static int indexPosImageMask;
    [Header("Note Data")]
    public Transform windowContent;
    public GameObject callTextObject;
    [Header("Position Mask")]
    public RectTransform imageMask;
    public List<RectTransform> posImageMask;
    private void Start()
    {
        imageMask.position = posImageMask[indexPosImageMask].position;

        //Enlazarlo con los niveles cuando este en el nivel 1 colocarlo con el de objetivos_1 y asi con todo

        //readFromFilePae = Application.dataPath + "/Textos/" + "/Text_Objective/" + "Objetives_Level_1" + ".txt";
        //string readFromFilePath = Application.dataPath + "/Textos/" + "/Text_Objective/" + "Objetives_Level_1" + ".txt";
        string readFromFilePath = Application.dataPath + "/Textos/Text_Objective/" + fileName + ".txt";
        //
        string fileLines = File.ReadAllText(readFromFilePath);
        //Instantiate(callTextObject, windowContent);
        callTextObject.GetComponent<Text>().text = fileLines;
    }
}