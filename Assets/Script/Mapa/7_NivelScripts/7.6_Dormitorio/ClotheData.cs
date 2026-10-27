using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClotheData : MonoBehaviour
{
    public static ClotheData clotheInfo;

    public int numCloth;
    private void Awake()
    {
        if(ClotheData.clotheInfo == null)
        {
            ClotheData.clotheInfo = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ResetearClothe() 
    {
        numCloth = 0;
    }
}
