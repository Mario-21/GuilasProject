using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class OneShotCerilla : MonoBehaviour
{
    PutGasMask maskCerilla;
    [SerializeField] EventReference audioSFX;

    int soundSFX;
    void Start()
    {
        maskCerilla = GetComponent<PutGasMask>();
    }

    // Update is called once per frame
    void Update()
    {
        if (maskCerilla.putMask)
        {
            if(soundSFX < 1)
            {
                AudioManager.instancia.PlayOneShot(audioSFX);
                soundSFX++;
            }
        }
    }
}
