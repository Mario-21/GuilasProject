using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infarmary : MonoBehaviour
{
    public int indexMod;

    [SerializeField] List<GameObject> soldierOnInfarmary;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            for(int i = 0; i < soldierOnInfarmary.Count; i++)
            {
                soldierOnInfarmary[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
