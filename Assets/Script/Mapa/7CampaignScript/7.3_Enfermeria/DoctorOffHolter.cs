using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorOffHolter : MonoBehaviour
{
    [SerializeField] OffHolter holter;
    [SerializeField] Transform holterPos;

    SoldadoNormal soldadoDoctor;
    float timeToGoHolter;
    void Start()
    {
        soldadoDoctor = GetComponent<SoldadoNormal>();
    }

    // Update is called once per frame
    void Update()
    {
        GoHolter();
    }
    void GoHolter()
    {
        if (!holter.onHolter)
        {
            timeToGoHolter += Time.deltaTime;
            if(timeToGoHolter >= 3)
            {
                soldadoDoctor.ubicacionesDirigir[0] = holterPos;
            }
        }
    }
}
