using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAll : MonoBehaviour
{
    public int indexModOpenDoor;

    public int indexCeilingPan;
    public int indexRecoveryRoom;
    public List<SoldadoNormal> soldados;

    BoxCollider2D box;


    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModOpenDoor].modificacion)
        {
            box.enabled = true;
        }
        else box.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!StatusGameobjectsVariables.statusGameobject.modificacion[indexCeilingPan].modificacion && !StatusGameobjectsVariables.statusGameobject.modificacion[indexRecoveryRoom].modificacion)
        {
            if (collision.gameObject.CompareTag("BalaPlayer"))
            {
                for (int i = 0; i < soldados.Count; i++)
                {
                    soldados[i].berserker = true;
                    soldados[i].outRange = 30;
                    soldados[i].insideRange = 20;
                }
            }
        }
        
    }
}
