using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialesMove : MonoBehaviour
{
    [Header("Flechas UI and Back")]
    public GameObject flechaIzquierda;
    public GameObject flechaDerecha;
    [Header("Fila Principal")]
    public RectTransform fila;
    public float velocidad;
    public List<RectTransform> tutoriales_Pos;

    bool mover;
    [HideInInspector]public int indexFila;

    enum Orientation
    {
        izquierda,
        derecha
    }
    Orientation directionFila;
    void Start()
    {
        fila.position = tutoriales_Pos[0].position;
        mover = false;
    }
    void Update()
    {
        ReglasFlechas();
        fila.position = tutoriales_Pos[indexFila].position;
        /*
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
        else
        {
            switch (directionFila)
            {
                case Orientation.izquierda:
                    DerechaDirection();
                    break;
                case Orientation.derecha:
                    IzquierdaDirection();
                    break;
            }
        }*/
    }
    void IzquierdaDirection()
    {
        if (fila.position.x > tutoriales_Pos[indexFila].position.x)
        {
            Debug.Log("Izquierda");
            fila.position = Vector2.MoveTowards(fila.position, tutoriales_Pos[indexFila].position, velocidad * Time.deltaTime);
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
        if (indexFila < tutoriales_Pos.Count - 1) indexFila++;
    }
    void DerechaDirection()
    {
        if (fila.position.x < tutoriales_Pos[indexFila].position.x)
        {
            Debug.Log("Derecha");
            fila.position = Vector2.MoveTowards(fila.position, tutoriales_Pos[indexFila].position, velocidad * Time.deltaTime);
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
        if (indexFila > 0) indexFila--;
    }
    void ReglasFlechas()
    {
        if (indexFila == 0)
        {
            flechaIzquierda.SetActive(false);
        }
        else
        {
            flechaIzquierda.SetActive(true);
        }
        if (indexFila == tutoriales_Pos.Count - 1)
        {
            flechaDerecha.SetActive(false);
        }
        else
        {
            flechaDerecha.SetActive(true);
        }
    }
}
