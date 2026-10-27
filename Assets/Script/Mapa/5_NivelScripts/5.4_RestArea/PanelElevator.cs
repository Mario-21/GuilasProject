using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelElevator : MonoBehaviour
{
    PlayerHere player;
    public GameObject panel;
    [SerializeField] ChooseFloorAscensor elevator;

    void Start()
    {
        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        SeePanel();
    }
    void SeePanel()
    {
        if (player.playerImHere)
        {
            panel.SetActive(true);
        }
        if (elevator.elevatorActive)
        {
            panel.SetActive(false);
        }
        
    }
    public void SelectFloor(int selectFloor)
    {
        elevator.nextFloor = selectFloor;
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            panel.SetActive(false);
            //Debug.Log("PLaer in Elevator");
        }
        
    }
}
