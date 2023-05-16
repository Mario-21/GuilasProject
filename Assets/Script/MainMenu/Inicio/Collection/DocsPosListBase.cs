using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DocsPosListBase
{
    public string nameDoc;
    public RectTransform posDocs;
    public RectTransform posDocsImageBase;
    public RectTransform posDocsImageNext;
    public RectTransform posDocsTextBase;
    public RectTransform posCarpetBackBase;
}
[System.Serializable]
public class DocsData
{
    public string name;
    public RectTransform docsImage;
    public RectTransform docsText;
    public RectTransform docsCarpet;
}
