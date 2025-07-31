using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcultarAccesorios : MonoBehaviour
{
    [SerializeField] Stairs_Hidden hidden;
    public GameObject accesorio_Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hidden.imHidden)
        {
            accesorio_Player.SetActive(false);
        }
        else
        {
            accesorio_Player.SetActive(true);
        }
    }
}
