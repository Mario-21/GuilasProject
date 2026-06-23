using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCompletarNivel : MonoBehaviour
{
    public GameObject completarNivel;
    public Transform ubiCompletarNivel;
    void Update()
    {
        completarNivel.transform.position = ubiCompletarNivel.position;
    }
}
