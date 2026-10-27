using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CambioCamaraIndex : MonoBehaviour
{
    public int indexMod;
    public CinemachineVirtualCamera mainCamera;
    public Transform newObjectiveCamera;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            mainCamera.Follow = newObjectiveCamera;
        }
    }
}
