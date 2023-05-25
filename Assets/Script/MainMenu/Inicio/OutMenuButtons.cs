using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutMenuButtons : MonoBehaviour
{
    public static bool colliderButtonsStatus;

    public BoxCollider2D[] collidersButtonMenu;


    public void Start()
    {
        colliderButtonsStatus = true;
    }
    private void Update()
    {
        Debug.Log("El estado de los collider Buttons es " + colliderButtonsStatus);
        if (colliderButtonsStatus)
        {
            On_Colliders_Buttons();
        }
        else
        {
            Off_Colliders_Buttons();
        }
    }
    void Off_Colliders_Buttons()
    {
        foreach (BoxCollider2D boxCollision in collidersButtonMenu)
        {
            boxCollision.enabled = false;
            Debug.Log("Nome");
        }
    }
    void On_Colliders_Buttons()
    {
        foreach (BoxCollider2D boxCollision in collidersButtonMenu)
        {
            boxCollision.enabled = true;
        }
    }
}
