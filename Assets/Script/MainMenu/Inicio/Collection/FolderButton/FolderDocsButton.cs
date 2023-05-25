using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FolderDocsButton : MonoBehaviour
{
    public int posDoc;

    public void DocsPosition()
    {
        CollectionDirection.botonDocs = false;
        DocsInfo.docsPosStart = posDoc;
        Debug.Log("Siguiente position " + DocsInfo.docsPosStart);
    }
}
