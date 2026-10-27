using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDisparo : MonoBehaviour
{
    public GameObject brazoRotation;
    public ParticleSystem effectoDisparoParticle;
    public Transform playerScale;
    public GameObject luzFake;
    public void AnimationEffectDisparo()
    {
        effectoDisparoParticle.Play();
        GameObject luzClone = Instantiate(luzFake, effectoDisparoParticle.transform.position, Quaternion.identity);
        Destroy(luzClone, 0.1f);
        if (playerScale.localScale.x > 0)
        {
            effectoDisparoParticle.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else if (playerScale.localScale.x < 0)
        {
            effectoDisparoParticle.transform.localRotation = new Quaternion(0f, 0f, 180f, 0f);
        }

    }
}
