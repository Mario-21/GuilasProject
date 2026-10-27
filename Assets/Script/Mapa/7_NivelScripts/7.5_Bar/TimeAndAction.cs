using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndAction : MonoBehaviour
{
    [Header("Who realiza the Action")]
    public string nameTag;
    [Header("Take Time to Do and Action")]
    public float timeActionLimit;
    [HideInInspector] public float timeAction;
    [HideInInspector] public bool onTime;

    [HideInInspector]public bool action;
    public void TimeActionOn()
    {
        if (onTime)
        {
            timeAction += Time.deltaTime;
            if (timeAction >= timeActionLimit)
            {
                action = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(nameTag))
        {
            onTime = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(nameTag))
        {
            onTime = false;
            timeAction = 0;
        }
    }
}
