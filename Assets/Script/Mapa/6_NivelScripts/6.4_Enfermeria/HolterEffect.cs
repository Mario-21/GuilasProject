using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolterEffect : MonoBehaviour
{
    public float velocidad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveHolter();
    }
    void MoveHolter()
    {
        transform.localPosition = new Vector3(transform.localPosition.x + velocidad, transform.localPosition.y, transform.localPosition.z);

        if (transform.localPosition.x >= 0.5)
        {
            transform.localPosition = new Vector3(-0.5f, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
