using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerValueParameter : MonoBehaviour
{
    [Header("Parameter Change")]
    [SerializeField] string parameterName;
    [Range(0,1)]
    [SerializeField] float parameterValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MusicAmbienceManager.instance.SetAmbienceParameterValue(parameterName, parameterValue);
        }
    }
}
