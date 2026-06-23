using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ListDestroyEndLevel : MonoBehaviour
{
    public static ListDestroyEndLevel levelList;
    public List<AnexoDestroyList> levelListDestroy;
    private void Awake()
    {
        if (ListDestroyEndLevel.levelList == null)
        {
            ListDestroyEndLevel.levelList = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Invoke("CompletarListaDestroy", 1f);
    }
    void CompletarListaDestroy()
    {
        levelListDestroy = FindObjectsOfType<AnexoDestroyList>().ToList();
        Debug.Log("Lista Completa Destructiva");
    }
}
