using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaSoldado : MonoBehaviour
{
    float vidaBala;
    float vidaBalaMax;
    private void Start()
    {
        vidaBalaMax = 5f;
    }
    private void Update()
    {
        vidaBala += Time.deltaTime;
        if (vidaBala >= vidaBalaMax) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.layer == 9 || collision.gameObject.CompareTag("Faker")) 
        {
            Destroy(this.gameObject);
        }
        
    }
}
