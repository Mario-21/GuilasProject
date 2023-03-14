using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKeyCarAppear : MonoBehaviour
{
    [Header("Variables Condictions")]
    public List<int> indexMods;
    public int numeroCondicionesLimite;
    int numeroCondiciones;
    [Header("Trigger Appear")]
    public GameObject triggerAppear;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Conditions();
        ClearConditions();
    }
    void Conditions()
    {
        for(int e = 0; e < indexMods.Count; e++)
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMods[e]].modificacion)
            {
                numeroCondiciones++;
                indexMods.Remove(indexMods[e]);
            }
        }
    }
    void ClearConditions()
    {
        if(numeroCondiciones >= numeroCondicionesLimite)
        {
            triggerAppear.SetActive(true);
            Debug.Log("Clear Conditions");
        }
    }
}
