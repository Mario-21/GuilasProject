using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bath : MonoBehaviour
{
    public int indexMod;

    [Header("ChangeThink")]
    [SerializeField] SpriteRenderer glassThink;
    [SerializeField] Sprite toiletThink;

    // Update is called once per frame
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            glassThink.sprite = toiletThink;
        }
    }
}
