using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyClothe : MonoBehaviour
{
    public int indexMod;

    PlayerHere player;
    [Header("Clothes Info")]
    public int totalClothes;
    public int indexAllClothes;
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
        TakeDirtyClothe(); 
    }
    void TakeDirtyClothe()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                CatchClothes();
                //Recogiendo ropa
                ExtraVariable.extras.numClothes++;
                if (ExtraVariable.extras.numClothes >= totalClothes) StatusGameobjectsVariables.statusGameobject.modificacion[indexAllClothes].modificacion = true;
            }
        }
    }
    void CatchClothes()
    {
        this.gameObject.SetActive(false);
    }
}
