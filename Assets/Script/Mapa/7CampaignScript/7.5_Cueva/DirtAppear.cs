using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtAppear : MonoBehaviour
{
    [Header("Activador Modificadores")]
    [SerializeField] ActivarModificador desenterrar_A;
    [SerializeField] ActivarModificador desenterrar_B;
    [Header("Spawn Position")]
    [SerializeField] Transform a;
    [SerializeField] Transform b;
    [Header("Item you Want")]
    [SerializeField] GameObject item;
    [SerializeField] GameObject item_2;
    int once_a;
    int once_b;

    // Update is called once per frame
    void Update()
    {
        SpawnOrder();
        SecondItem();
    }
    void SpawnOrder()
    {
        if(once_a < 1 && once_b < 1)
        {
            if (desenterrar_A.modificacion)
            {
                item.transform.position = a.position;
                once_a++;
            }
            else if (desenterrar_B.modificacion)
            {
                item.transform.position = b.position;
                once_b++;
            }
        }
    }
    void SecondItem()
    {
        //Si ha aparecido en b el segundo item saldra en a
        if (once_a < 1 && once_b >= 1 && desenterrar_A.modificacion)
        {
            item_2.transform.position = a.position;
            once_a++;
        }
        //Si ha aparecido en a el segundo item saldra en b
        else if(once_a >= 1 && once_b < 1 && desenterrar_B.modificacion)
        {
            item_2.transform.position = b.position;
            once_b++;
        }
    }
}
