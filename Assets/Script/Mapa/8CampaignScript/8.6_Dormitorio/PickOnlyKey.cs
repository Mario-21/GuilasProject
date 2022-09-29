using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickOnlyKey : MonoBehaviour
{
    [Header("Conditions Pick Key without Laundry Box")]
    public int indexDiarySleep;
    [SerializeField] SoldierLife soldierDiary;
    [Header("Key Info")]
    [SerializeField] CogerObjeto withLaundry; 
    [SerializeField] CogerObjeto keyNormal; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PickKeyNoLaundry();
    }
    void PickKeyNoLaundry()
    {
        if(soldierDiary.vida <= 0 || StatusGameobjectsVariables.statusGameobject.modificacion[indexDiarySleep].modificacion)
        {
            withLaundry.enabled = false;
            keyNormal.enabled = true;
        }
    }
}
