using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarSoldier : MonoBehaviour
{
    [Header("Soldado Girar")]
    [SerializeField] Transform scaleSoldier;
    [Header("Tiempo Girar")]
    public float timeGirarLimit;
    float timeGirar;
    [Header("Direction Giro")]
    [Range(-1,1)]
    public int girarScale;

    bool girar;
    void Update()
    {
        if (girar)
        {
            timeGirar += Time.deltaTime;
            if(timeGirar >= timeGirarLimit)
            {
                scaleSoldier.localScale = new Vector3(girarScale, 1, 1);
                girar = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            girar = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            girar = false;
        }
    }
}
