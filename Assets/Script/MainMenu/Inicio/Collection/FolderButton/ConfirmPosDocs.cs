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

    //Colocar el load aqui o en su defecto colocar que lo haga en la lista de reliquias, para no hacer tanta cosa
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
        for (int i = 0; i < ListaReliquias.instancia.listaReliquiasTotal.Count; i++)
        {
            if (ListaReliquias.instancia.listaReliquiasTotal[i].reliquiaObtenida)
            {
                Debug.Log("Dos ver man " + folderDocs[i].posDoc);
                folderDocs[i].posDoc = reliquiaPosDoc;
                reliquiaPosDoc++;

            }
        }
    }

}
