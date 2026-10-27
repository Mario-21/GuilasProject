using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliquiaPosValvula : MonoBehaviour
{
    [SerializeField] Transform reliquiaPos;
    public List<Transform> ubiAllReliquia;
    void Start()
    {
        reliquiaPos.position = ubiAllReliquia[ClotheData.clotheInfo.numCloth].position;
    }
}
