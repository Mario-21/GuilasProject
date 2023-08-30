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
    [SerializeField] bool itemInClothe;
    CogerObjeto item;
    void Start()
    {
        if (itemInClothe) item = GetComponent<CogerObjeto>();
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
            if (Input.GetButtonDown("UseMask"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.laundryClothes);
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                //Recogiendo ropa
                CatchClothes();
                //Item Ropa si tienes
                if (itemInClothe) item.Pick();
                //ESto servía para saber cuanta ropa habias recogido, y cuando llegaras al tope la variable se activava
                //Aplicar la misma que Liquid
                ClotheData.clotheInfo.numCloth++;
                if (ClotheData.clotheInfo.numCloth >= totalClothes) StatusGameobjectsVariables.statusGameobject.modificacion[indexAllClothes].modificacion = true;
            }
        }
    }
    void CatchClothes()
    {
        this.gameObject.SetActive(false);
    }
}
