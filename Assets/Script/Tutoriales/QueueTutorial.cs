using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueTutorial : MonoBehaviour
{
    Image imageQueue;
    // Start is called before the first frame update
    void Start()
    {
        imageQueue = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ControlerTutoriales.instanciaTutoriales.colaTutoriales.Count > 1)
        {
            imageQueue.enabled = true;
        }
        else
        {
            imageQueue.enabled = false;
        }
    }
}
