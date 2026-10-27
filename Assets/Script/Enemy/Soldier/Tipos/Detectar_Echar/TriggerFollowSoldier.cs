using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFollowSoldier : MonoBehaviour
{
    [SerializeField] Transform soldadoScaleX;
    [SerializeField] Transform ubiTrigger;
    void Update()
    {
        transform.position = ubiTrigger.position;
        transform.localScale = new Vector3(soldadoScaleX.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
