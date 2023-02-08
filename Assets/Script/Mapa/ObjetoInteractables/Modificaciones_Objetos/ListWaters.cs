using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListWaters : MonoBehaviour
{
    public static ListWaters listWaters;
    public List<float> indexLevelWater;
    private void Awake()
    {
        if (ListWaters.listWaters == null)
        {
            ListWaters.listWaters = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
