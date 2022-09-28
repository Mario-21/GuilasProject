using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeClothe : MonoBehaviour
{
    [Header("Basket Player")]
    [SerializeField] PutGasMask basket;
    [Header("Clothes Info")]
    [SerializeField] List<BoxCollider2D> clothes;
    public int clothesCount;
    void Update()
    {
        ActiveClothes();
    }
    void ActiveClothes()
    {
        if (basket.putMask && clothesCount < 1)
        {
            foreach(BoxCollider2D clothe in clothes)
            {
                clothe.enabled = true;
            }
            clothesCount++;
        }
    }
}
