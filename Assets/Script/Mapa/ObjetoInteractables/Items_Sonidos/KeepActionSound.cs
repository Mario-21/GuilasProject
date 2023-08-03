using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PressActionSounds))]
public class KeepActionSound : MonoBehaviour
{
    public int indexMod;

    PressActionSounds pressActionConditions;
    private void Awake()
    {
        pressActionConditions = GetComponent<PressActionSounds>();
    }
    void Start()
    {
        //Solo se requiere con los objetos emissores, en caso de necesitarlo el PlayOneShot solo sería si el objeto en cuestion tiene dos sonidos diferentes al action estar en verdadero o falso
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
           pressActionConditions.action = true;
        }
    }
}
