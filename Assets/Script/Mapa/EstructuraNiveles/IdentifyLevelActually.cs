using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdentifyLevelActually : MonoBehaviour
{
    void Start()
    {
        EstructuraNiveles.nivel = SceneManager.GetActiveScene().buildIndex;
        EstructuraNiveles.nombreNivel = SceneManager.GetActiveScene().name;
    }
}
