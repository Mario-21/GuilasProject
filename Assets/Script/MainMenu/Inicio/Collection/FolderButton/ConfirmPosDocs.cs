using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmPosDocs : MonoBehaviour
{
    public List<FolderDocsButton> folderDocs;
    public int reliquiaPosDoc;

    int once;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(once < 1)
        {
            BotonFolderPosAsignar();
            once++;
        }
        
    }
    void BotonFolderPosAsignar()
    {
        for (int i = 0; i < ListaReliquias.listaReliquiasTotal.Count; i++)
        {
            if (ListaReliquias.listaReliquiasTotal[i].reliquiaObtenida)
            {
                Debug.Log("Dos ver man " + folderDocs[i].posDoc);
                folderDocs[i].posDoc = reliquiaPosDoc;
                reliquiaPosDoc++;

            }
        }
    }
}
