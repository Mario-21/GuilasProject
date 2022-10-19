using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCoche : MonoBehaviour
{
    PlayerHere player;

    [SerializeField] SoldadoNormal boss;

    public int indexMod;

    [Header("Fall Item")]
    public GameObject fallItem;

    [Header("Elevator")]
    [SerializeField] Transform elevador;
    [SerializeField] Transform[] ubiElevator;

    bool onElevator;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
            elevador.position = ubiElevator[0].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ElevatorVehicle();
        ElevatorMove();
    }
    void ElevatorVehicle()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z) && !StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
            {
                onElevator = true;
                boss.enabled = false;
                fallItem.SetActive(true);
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;

            }
        }
    }
    void ElevatorMove()
    {
        if (onElevator)
        {
            Vector2 movePosition = elevador.position;
            elevador.position = Vector2.MoveTowards(elevador.position, ubiElevator[0].position, 1 * Time.deltaTime);
        }
    }
}
