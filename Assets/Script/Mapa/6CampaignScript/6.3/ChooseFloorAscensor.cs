using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ChooseFloorAscensor : MonoBehaviour
{
    Rigidbody2D rb;
    int actualFloor;
    public int nextFloor;
    [HideInInspector] public bool elevatorActive;

    [Header("Velocity")]
    public float speed;

    [Header("Floor's Elevator")]
    public List<Transform> floors;

    [Header("Rope of Elevator")]
    [SerializeField] SpriteRenderer cuerda;
    float cuerda_Size;

    StudioEventEmitter emissorAscensor;
    int soundReproduce;
    private void Awake()
    {
        actualFloor = nextFloor;
        rb = GetComponent<Rigidbody2D>();
        cuerda_Size = speed / 10;
    }
    void Start()
    {
        emissorAscensor = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.ascensorMove, this.gameObject);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Elevator();
    }
    void Elevator()
    {
        Vector3 movePosition = transform.position;
        movePosition.y = Mathf.MoveTowards(transform.position.y, floors[nextFloor].position.y, speed * Time.fixedDeltaTime);
        rb.MovePosition(movePosition);

        //Mientras no hayas llegado a tu destino la cuerda aumentara
        if (transform.position != floors[nextFloor].position)
        {
            ElevatorRope();
            ElevatorSound();
            elevatorActive = true;
        }
        else 
        {
            emissorAscensor.Stop();
            soundReproduce = 0;
            actualFloor = nextFloor;
            elevatorActive = false;
        }
        
        
    }
    void ElevatorRope()
    {
        if(actualFloor < nextFloor)
        {
            //Rope Minus and Up = true;
            cuerda.size -= new Vector2(0f, cuerda_Size);
        }
        else if(actualFloor > nextFloor)
        {
            //Rope Increase and UP false
            cuerda.size += new Vector2(0f, cuerda_Size);
        }
    }
    void ElevatorSound()
    {
        if(soundReproduce < 1)
        {
            emissorAscensor.Play();
            soundReproduce++;
        }
    }
}
