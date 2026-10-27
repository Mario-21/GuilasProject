using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClotheRevive : MonoBehaviour
{
    ClotheRevive reviveCloth;
    void Start()
    {
        if (reviveCloth == null)
        {
            reviveCloth = FindObjectOfType<ClotheRevive>();
        }
    }

    public void ClothesReviveButton()
    {
        if (reviveCloth != null) reviveCloth.ReviveClothes();
    }
}
