using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldadoDormidoCama : MonoBehaviour
{
    Animator headAnim;
    [SerializeField] ParticleSystem particulasDormir;

    private void Awake()
    {
        headAnim = GetComponent<Animator>();
    }
    void Start()
    {
        headAnim.SetBool("Muerte", true);
        particulasDormir.Play();
    }
}
