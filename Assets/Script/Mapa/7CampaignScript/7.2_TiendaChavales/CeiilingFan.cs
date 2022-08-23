using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeiilingFan : MonoBehaviour
{
    public int indexMod;
    public float speed;
    public  bool onCeilingFan;
    [SerializeField] Transform ceilingFan;

    PlayerHere player;
    void Start()
    {
        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ActiveCeilingFan();
            CeilingFan();
        }
    }
    void ActiveCeilingFan()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                onCeilingFan = !onCeilingFan;
            }
        }
        
    }
    void CeilingFan()
    {
        if (onCeilingFan)
        {
            ceilingFan.Rotate(0f, speed, 0f);
        }
        else
        {
            ceilingFan.Rotate(0f, 0f, 0f);
        }
    }
}
