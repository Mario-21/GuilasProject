using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SoundArchives : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] EventReference sfx_Archives;
    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AudioManager.instancia.PlayOneShot(sfx_Archives);
        }
    }
}
