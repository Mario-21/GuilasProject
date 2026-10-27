using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class NoviceWriteCin : MonoBehaviour
{
    public int indexMod;
    [Header("Soldado Info")]
    [SerializeField] SoldadoNormal soldadoNovato;
    [SerializeField] GameObject bocadillo;
    [Header("Tiempo Cinematica")]
    [SerializeField] float limitTimeCin;
    float timeCin;
    [Header("Sonido Write")]
    [SerializeField] EventReference writeSound;
    int soundReproduce;

    // Start is called before the first frame update
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            if (soundReproduce < 1) { AudioManager.instancia.PlayOneShot(writeSound); soundReproduce++; }
            timeCin += Time.deltaTime;
            if (timeCin >= limitTimeCin)
            {
                bocadillo.SetActive(false);
                soldadoNovato.enabled = true;
            }
        }
    }
}
