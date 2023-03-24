using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAditive : MonoBehaviour
{
    public int scenaAditiva;
    public int openTries;

    public bool s4;
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
        if (Input.GetKeyDown(KeyCode.L))
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
