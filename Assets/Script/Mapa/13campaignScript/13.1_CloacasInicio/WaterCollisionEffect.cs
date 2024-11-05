using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollisionEffect : MonoBehaviour
{
    [Header("Particulas Chapoteo")]
    public GameObject chapoteoParticle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform ubiPlayerAgua = collision.gameObject.transform;

            Vector3 ubiPlayerFake = ubiPlayerAgua.position + (Vector3.down / 2);

            Instantiate(chapoteoParticle, ubiPlayerFake, ubiPlayerAgua.rotation);
        }
    }
}
