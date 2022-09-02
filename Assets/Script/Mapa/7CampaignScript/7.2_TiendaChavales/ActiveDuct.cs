using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDuct : MonoBehaviour
{
    public int indexScrewDriver;
    [SerializeField] Duct duct;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexScrewDriver].modificacion)
        {
            duct.enabled = true;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexScrewDriver].modificacion)
        {
            duct.enabled = true;
        }
    }
}
