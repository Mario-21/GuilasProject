using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDestroyEndLevel : MonoBehaviour
{
    public static ListDestroyEndLevel levelList;
    public List<GameObject> levelListDestroy;
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
}
