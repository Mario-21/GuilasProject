using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReliquiaValvula : MonoBehaviour
{
    [Header("Reliquia Data")]
    [SerializeField] Transform reliquiaPos;
    public List<Transform> ubiAllReliquia;
    void Update()
    {
        reliquiaPos.position = ubiAllReliquia[ClotheData.clotheInfo.numCloth].position;
    }
}
