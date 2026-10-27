using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutVariable : MonoBehaviour
{
    public int indexMod;
    PlayerHere player;

    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            Out_Variable();
        }
    }
    void Out_Variable()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = false;
            }
        }
    }
       
    
}
