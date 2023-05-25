using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharks : MonoBehaviour
{
    public VidaPlayer playerLife;
    public float dañoShark;

    //Añadir Trigger SharkBool
    public float sharkSpeed;
    public Transform izquierda, derecha;
    public float scaleNegative;

    public bool wait;
    public float waitTime;

    public enum DirectionShark
    {
        derecha,
        izquierda
    }
    public DirectionShark directionShark;

    public SharkSpawn sharkSpawn;
    void Start()
    {
        //sharkSpawn = GetComponent<SharkSpawn>();
        transform.position = sharkSpawn.spawn.position;
        playerLife = GameObject.FindObjectOfType<VidaPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Abs(scaleNegative);
        WaitShark();
        switch (directionShark)
        {
            case DirectionShark.derecha:
                //Rotar tambien las particulas
                SharkMoveDerecha();
                break;
            case DirectionShark.izquierda:
                Debug.Log("Izquierda Shark");
                SharkMoveIzquierda();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Choca Shark");
            playerLife.Daño(dañoShark);
        }
    }
    void SharkMoveDerecha()
    {
        transform.localScale = new Vector3(transform.localScale.x, -scaleNegative, transform.localScale.z);
        if (transform.position.x < derecha.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, derecha.position, sharkSpeed * Time.deltaTime);
        }
        else
        {
            wait = true;
        }
    }
    void SharkMoveIzquierda()
    {
        if (transform.position.x > izquierda.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, izquierda.position, sharkSpeed * Time.deltaTime);
        }
        else
        {
            wait = true;
        }
    }
    void WaitShark()
    {
        if (wait)
        {
            waitTime += Time.deltaTime;
            if (waitTime >= 2.5f)
            {
                waitTime = 0;
                //Si estabas a la derecha te diriges ahora a la izquierda
                if (directionShark == DirectionShark.derecha)
                {
                    transform.localScale = new Vector3(transform.localScale.x, scaleNegative, transform.localScale.z);
                    directionShark = DirectionShark.izquierda;
                }
                //Si estabas a la izquierda te diriges ahora a la derecha
                else if (directionShark == DirectionShark.izquierda)
                {
                    transform.localScale = new Vector3(transform.localScale.x, -scaleNegative, transform.localScale.z);
                    directionShark = DirectionShark.derecha;
                }
                wait = false;
            }
        }
    }
    private void OnDisable()
    {
        //Esto se desactiva, por tanto el tiburon esta en la superficie del agua y bajara
        sharkSpawn.entryShark = true;
        sharkSpawn.up_DownShark = SharkSpawn.EntryOutShark.down;
        Debug.Log("Shark Out");
    }
    private void OnEnable()
    {
        //Esto es activado, por tanto el tiburon subira a la superficie
        sharkSpawn.entryShark = true;
        sharkSpawn.up_DownShark = SharkSpawn.EntryOutShark.up;
        Debug.Log("Shark Entry");
    }
}
