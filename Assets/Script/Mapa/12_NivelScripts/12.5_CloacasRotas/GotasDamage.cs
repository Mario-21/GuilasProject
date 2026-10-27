using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotasDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public VidaPlayer playerLife;
    public float dañoParticle;
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerLife.Daño(dañoParticle);
        }
    }
}
