using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAscensorFloor : MonoBehaviour
{
    public int floor;
    public ChooseFloorAscensor ascensor;
    public List<BoxCollider2D> boxesFloor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ascensor.nextFloor = floor;
            foreach(BoxCollider2D box in boxesFloor)
            {
                box.enabled = false;
            }
        }
    }
}
