using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class RuleCameraCin : MonoBehaviour
{
    public int indexBoss;
    [Header("Main Camera")]
    public CinemachineVirtualCamera mainCamera;
    [Header("Asistente Main Camera")]
    public Transform asistente;
    [Header("Boss Main Camera")]
    public Transform boss;
    void Start()
    {
        MainCharacter();
    }

    // Update is called once per frame
    void MainCharacter()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexBoss].modificacion)
        {
            mainCamera.Follow = asistente;
        }
        else
        {
            mainCamera.Follow = boss;
        }
    }
}
