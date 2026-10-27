using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCarTrigger : MonoBehaviour
{
    public bool RangeCar;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RangeCar = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RangeCar = false;
        }
    }
    private void OnDestroy()
    {
        RangeCar = false;
    }
}
