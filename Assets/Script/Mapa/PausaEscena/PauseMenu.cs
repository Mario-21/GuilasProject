using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public int scenaAditiva;
    public static int openTries;
    private void Awake()
    {

    }
    void Start()
    {
        //scene.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("El open Tries es " + openTries);
        if (Input.GetButtonDown("Cancel"))
        {   
            if (openTries < 1)
           {
                Time.timeScale = 0;
                SceneManager.LoadSceneAsync(scenaAditiva, LoadSceneMode.Additive);
                openTries++;
            }
           else if (openTries >= 1)
            {
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(scenaAditiva);
                openTries = 0;
            }
        }
    }
}
