using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoControlerInGame : MonoBehaviour
{
    public static bool tutoActive;
    public static GameObject tutoActual;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tutoActual != null)
        {
            Debug.Log("Existo y soy " + tutoActual.name);
        }
        else
        {
            Debug.Log("No existo");
        }
    }
}
