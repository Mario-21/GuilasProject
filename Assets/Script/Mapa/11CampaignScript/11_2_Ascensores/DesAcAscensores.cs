using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesAcAscensores : MonoBehaviour
{
    public List<GameObject> panelesAsccensor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for(int i = 0; i < panelesAsccensor.Count; i++)
            {
                panelesAsccensor[i].SetActive(false);
            }
        }
    }
}
