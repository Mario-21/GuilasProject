using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClotheRevive : MonoBehaviour
{
    public int numClotheStart;
    void Start()
    {
        numClotheStart = ClotheData.clotheInfo.numCloth;
    }

    // Update is called once per frame
    public void ReviveClothes()
    {
        ClotheData.clotheInfo.numCloth = numClotheStart;
    }
}
