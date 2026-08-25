using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarEquipamiento : MonoBehaviour
{
    public string idTutorialDeseado;
    public PutGasMask equipo;
    public GameObject tutoDeseado;

    bool tutorialActivado;

    private void Start()
    {
        GameDataNoDestroy.instance.gameData.tutorialesCollected.TryGetValue(idTutorialDeseado, out  tutorialActivado);
        if (tutorialActivado)
        {
            this.enabled = false;
        }
    }
    void Update()
    {
        //En cuanto detecta que el objeto ha sido equipado, salta el tutorial
        if (equipo.putMask)
        {
            Instantiate(tutoDeseado, this.transform.position, Quaternion.identity);
            this.enabled = false;
            //tutoGameEquipado.enabled = true;
        }
    }
}
