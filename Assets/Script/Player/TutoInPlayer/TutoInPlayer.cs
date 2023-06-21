using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoInPlayer : MonoBehaviour
{
    public int indexMod;
    [SerializeField] PutGasMask mask;
    public GameObject tutorial;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion && mask.putMask)
        {
            Instantiate(tutorial);
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            this.enabled = false;
        }
    }
}
