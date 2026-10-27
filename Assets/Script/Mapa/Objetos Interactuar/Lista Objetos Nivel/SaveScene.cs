using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScene : MonoBehaviour
{

    public static SaveScene instancia;

    #region ListaItemsNivel
    public List<ListaTodosObjetos> listaItemsNivelGuardar;
    #endregion
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
    public void ResetearItemNivel()
    {
        for(int i = 0; i < listaItemsNivelGuardar.Count; i++)
        {
            listaItemsNivelGuardar[i].objetoObtenido = false;
            listaItemsNivelGuardar[i].ubiPosButton = 0;
            listaItemsNivelGuardar[i].vecesUsadoObjeto = 0;
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("OnSceneLoaded: " + scene.name);
    }
}
