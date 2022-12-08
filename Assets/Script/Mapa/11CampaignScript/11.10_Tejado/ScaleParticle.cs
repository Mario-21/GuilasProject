using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleParticle : MonoBehaviour
{
    [SerializeField] Transform enemy;
    void Update()
    {
        Scale();
    }
    void Scale()
    {
        if(enemy.localScale.x == 1)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (enemy.localScale.x == -1)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }
}
