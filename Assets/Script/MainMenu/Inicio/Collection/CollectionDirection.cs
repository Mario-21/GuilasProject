using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionDirection : MonoBehaviour
{
    [Header("Fila Principal")]
    public RectTransform fila;
    public float velocidad;
    public List<RectTransform> carpeta_Pos;
    public bool mover;

    public int indexFila;

    //NOTA; Es inversamente proporcional, si le doy a la derecha la fila se mueve hacía la izquierda;
    //Si le doy a la izquierda la fila se mueve a la derecha

    enum Orientation
    {
        izquierda,
        derecha
    }
    Orientation directionFila;
    void Start()
    {
        indexFila = 0;
        fila.position = carpeta_Pos[0].position;
        mover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mover)
        {
            switch (directionFila)
            {
                case Orientation.izquierda:
                    IzquierdaDirection();
                    break;
                case Orientation.derecha:
                    DerechaDirection();
                    break;
            }
        }
    }

    void IzquierdaDirection()
    {
        if (fila.position.x > carpeta_Pos[indexFila].position.x)
        {
            Debug.Log("Izquierda");
            fila.position = Vector2.MoveTowards(fila.position, carpeta_Pos[indexFila].position, velocidad * Time.deltaTime);
        }
        else
        {
            mover = false;
        }
    }
    public void DerechaButton()
    {
        mover = true;
        directionFila = Orientation.izquierda;
        indexFila++;
    }
    void DerechaDirection()
    {
        if (fila.position.x < carpeta_Pos[indexFila].position.x)
        {
            Debug.Log("Derecha");
            fila.position = Vector2.MoveTowards(fila.position, carpeta_Pos[indexFila].position, velocidad * Time.deltaTime);
        }
        else
        {
            mover = false;
        }
    }
    public void IzquierdaButton()
    {
        mover = true;
        directionFila = Orientation.derecha;
        indexFila--;
    }
}
