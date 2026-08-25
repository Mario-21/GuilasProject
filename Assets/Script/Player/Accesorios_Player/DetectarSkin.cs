using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarSkin : MonoBehaviour
{
    public string idTutorialDeseado;
    public ChangeSkinPlayer skinEquipada;
    public GameObject tutoDeseado;

    bool tutorialActivado;
    private void Start()
    {
        GameDataNoDestroy.instance.gameData.tutorialesCollected.TryGetValue(idTutorialDeseado, out tutorialActivado);
        if (tutorialActivado)
        {
            this.enabled = false;
        }
    }
    void Update()
    {
        if (skinEquipada.putSkin)
        {
            Instantiate(tutoDeseado, this.transform.position, Quaternion.identity);
            this.enabled = false;
        }
    }
}
