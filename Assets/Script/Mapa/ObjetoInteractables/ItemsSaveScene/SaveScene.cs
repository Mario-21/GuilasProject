using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene : MonoBehaviour
{

    public static SaveScene instancia;

    #region ListaItemsNivel
    public List<ListaTodosObjetos> listaItemsNivelGuardar;
    #endregion

    //Quiero que ocurra en contadas escenas
    private void Awake()
    {
        if (SaveScene.instancia == null)
        {
            SaveScene.instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ClearListIteams()
    {
        for(int i = 0; i < listaItemsNivelGuardar.Count; i++)
        {
            listaItemsNivelGuardar[i].objetoObtenido = false;
            listaItemsNivelGuardar[i].ubiPosButton = 0;
            listaItemsNivelGuardar[i].vecesUsadoObjeto = 0;
        }
    }






}
