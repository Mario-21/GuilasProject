using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundActiveArea : MonoBehaviour
{
    [SerializeField] JugadorMovimiento movPlayer;
    [SerializeField] GameObject areaCambio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movPlayer.onGround)
        {
            areaCambio.SetActive(true);
        }
        else
        {
            areaCambio.SetActive(false);
        }
        
    }
}
