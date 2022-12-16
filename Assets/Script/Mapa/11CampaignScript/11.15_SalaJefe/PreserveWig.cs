using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreserveWig : MonoBehaviour
{
    [SerializeField] PutGasMask wig;
    void Start()
    {
        //Conservar el status de la peluca, para la siguiente cinematica
        wig.putMask = ExtraVariable.extras.preserveWig;
        if (wig.putMask)
        {
            wig.gas_Mask.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        ExtraVariable.extras.preserveWig = wig.putMask;
    }
}
