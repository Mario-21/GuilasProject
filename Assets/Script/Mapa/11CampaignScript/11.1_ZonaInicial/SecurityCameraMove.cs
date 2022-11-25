using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraMove : MonoBehaviour
{
    [Header("Limite Posicion Camara")]
    public float timeCameraLimit;
    public bool derecha;
    public float timeCamera;
    [Header("Velocidad Movimiento")]
    public float velocidad;
    float velocidadDefault;
    [Header("Limite Grados Cámara Rotación")]
    public float limitCameraRot;
    float limitRotCameraDrcha;
    float limitRotCameraIzq;
    void Start()
    {
        //Establecer Limite Derecha
        limitRotCameraDrcha = limitCameraRot;
        //Establecer Limite Izquierda
        limitRotCameraIzq = 360 - limitCameraRot;
        //Establecer Velocidad Default
        velocidadDefault = Mathf.Abs(velocidad);

        //Velocidad Inicial
        if (derecha)
        {
            velocidad = Mathf.Abs(velocidad) * 1;
        }
        else
        {
            velocidad = Mathf.Abs(velocidad) * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMoveCamera();
    }
    void ChangeMoveCamera()
    {
        //Si la cámara se dirige a la derecha
        if (derecha)
        {
            Debug.Log("Derecha Cámara");
            if (transform.eulerAngles.z > limitRotCameraDrcha || transform.eulerAngles.z < limitRotCameraIzq)
            {
                Debug.Log("Quiero Rotar");
                transform.Rotate(0, 0, velocidad);
            }

            //Tras pasar el limite se esperara un tiempo y comenzará a girar en la otra dirección
            if (transform.eulerAngles.z >= limitRotCameraDrcha && transform.eulerAngles.z < limitRotCameraIzq)
            {
                velocidad = 0;
                timeCamera += Time.deltaTime;
                if (timeCamera >= timeCameraLimit)
                {
                    //Cambias y te diriges a la izquierda
                    velocidad = velocidadDefault * -1;
                    derecha = false;
                    timeCamera = 0;
                }
            }
        }
        //Si la cámara se dirige a la izquierda
        else
        {
            Debug.Log("Izquierda Cámara");
            //Primera Condición
          
            /*Cuando este al lado derecho con <<X>> la cámara rotara si Z Actual es  < que el limite por la izquierda, pero, IMPORTANTE
            al rebasar el z = 0 este ahora será el 360º, anulando esa condición y haciendo que tengas que colocar la segunda. Z < limite por la derecha
            para poder continuar girando */
            if (transform.eulerAngles.z < limitRotCameraIzq || transform.eulerAngles.z > limitRotCameraDrcha)
            {
                Debug.Log("Quiero Rotar");
                transform.Rotate(0, 0, velocidad);
            }
            //Segunda Condición

            //Tras la dos condiciones anteriores solo habría que pedirle de nuevo la condición del límite por la izquierda, para que cuando se cumpla anular la velocidad. 
            if (transform.eulerAngles.z <= limitRotCameraIzq && transform.eulerAngles.z > limitRotCameraDrcha)
            {
                Debug.Log("Quiero llorar");
                velocidad = 0;
                timeCamera += Time.deltaTime;
                if (timeCamera >= timeCameraLimit)
                {
                    //Cambias y te diriges a la derecha.
                    velocidad = velocidadDefault * 1;
                    derecha = true;
                    timeCamera = 0;
                }
            }
        }
    }
}
