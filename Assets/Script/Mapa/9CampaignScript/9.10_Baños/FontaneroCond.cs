using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontaneroCond : MonoBehaviour
{
    public int indexFontanero;
    [SerializeField] BoxCollider2D vaterCollider;
    void Start()
    {
        if (SoldierActiveInScene.instancia.soldiersStatus[indexFontanero].statusVida <= 0) vaterCollider.enabled = false;
    }
}
