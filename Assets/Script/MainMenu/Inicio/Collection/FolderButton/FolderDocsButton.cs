using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderDocsButton : MonoBehaviour
{
    public int posDoc;

    public void DocsPosition()
    {
        DocsInfo.docsPosStart = posDoc;
        Debug.Log("Siguiente position " + DocsInfo.docsPosStart);
    }
}
