using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnTutoriales : MonoBehaviour
{
    //Habrá que hacerlo statico++
    public int scenaSpawnTutorial;
    public static int spawnTutorial;

    public List<GameObject> tutoriales;
    SceneAditive pause;
    void Start()
    {
        pause = FindObjectOfType<SceneAditive>();
        var spawn = Instantiate(tutoriales[spawnTutorial]);
        spawn.transform.parent = gameObject.transform;
        //parentItem.transform.parent = tutoriales[spawnTutorial].transform;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync(scenaSpawnTutorial);
            pause.enabled = true;
        }
    }
}
    