using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarEquipamientoDobleAction : MonoBehaviour
{
    public PutGasMask equipo;
    public string idTutorialDeseado1;
    public string idTutorialDeseado2;
    public GameObject tutoDeseado1;
    public GameObject tutoDeseado2;

    bool tutorialActivado1;
    bool tutorialActivado2;

    int limitSpawn;
    int limitSpawn2;

    float time;
    private void Start()
    {
        GameDataNoDestroy.instance.gameData.tutorialesCollected.TryGetValue(idTutorialDeseado1, out tutorialActivado1);
        GameDataNoDestroy.instance.gameData.tutorialesCollected.TryGetValue(idTutorialDeseado2, out tutorialActivado2);
        if (tutorialActivado1 && tutorialActivado2)
        {
            this.enabled = false;
        }
    }
    void Update()
    {
        //En cuanto detecta que el objeto ha sido equipado, salta el tutorial
        if (equipo.putMask)
        {
            StartCoroutine("OrdenSpawnTuto");
            /*
            time += Time.deltaTime;
            if (limitSpawn < 1) { Instantiate(tutoDeseado1, this.transform.position, Quaternion.identity); limitSpawn++; }
            if(time >= 2)
            {
                //if (limitSpawn2 < 1) { Instantiate(tutoDeseado2, this.transform.position, Quaternion.identity); limitSpawn2++; }
                this.enabled = false;
            }*/
            //tutoGameEquipado.enabled = true;
        }
    }
    IEnumerator OrdenSpawnTuto()
    {
        if (limitSpawn < 1) { Instantiate(tutoDeseado1, this.transform.position, Quaternion.identity); limitSpawn++; }
        yield return new WaitForSeconds(.5f);
        if (limitSpawn2 < 1) { Instantiate(tutoDeseado2, this.transform.position, Quaternion.identity); limitSpawn2++; }
        this.enabled = false;
    }
}
