using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyClothe : MonoBehaviour
{
    public int indexMod;

    PlayerHere player;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            CatchClothes();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TakeDirtyClothe()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                CatchClothes();
            }
        }
    }
    void CatchClothes()
    {
        this.gameObject.SetActive(false);
    }
}
