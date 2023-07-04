using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlockTemple : MonoBehaviour
{
    public int indexTrampasTemplo;
    [SerializeField] CogerObjeto itemTemplo;
    [SerializeField] GameObject bloqueosEstatua;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexTrampasTemplo].modificacion)
        {
            bloqueosEstatua.SetActive(false);
            itemTemplo.enabled = true;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexTrampasTemplo].modificacion)
        {
            bloqueosEstatua.SetActive(false);
            itemTemplo.enabled = true;
            this.enabled = false;
        }
    }
}
