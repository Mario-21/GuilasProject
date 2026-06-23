using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViajarEscenaManualmente : MonoBehaviour
{
    [Tooltip("EL nombre de Escena solo sirve con anim desactivado")]
    public string nombreEscena;
    public bool anim;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (anim)
            {
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
            }
            else
            {
                SceneManager.LoadScene(nombreEscena);
            }
        }
    }
}
