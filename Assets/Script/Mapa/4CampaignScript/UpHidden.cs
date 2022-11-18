using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class UpHidden : MonoBehaviour
{
    Stairs_Hidden hidden;
    bool imHere;
    [Header("Camera Data")]
    [SerializeField] CinemachineVirtualCamera mainCamera;
    [SerializeField] Transform player;
    [SerializeField] Transform puertaTransporte;
    [Header("Where do you want to go")]
    [SerializeField] Transform direction;
    [SerializeField] Image up_DownHidden;

    bool resetCamera;
    float timeWaitReset;
    private void Awake()
    {
        hidden = FindObjectOfType<Stairs_Hidden>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveHidden();
        CameraDefault();
    }
    void MoveHidden()
    {
        if(hidden.imHidden && imHere)
        {
            ArrowUI();

            if (Input.GetKeyDown(KeyCode.Z)) 
            {
                //Teletransporta a mi jugador a la zona.
                hidden.GetComponent<Transform>().position = direction.position;
                //Resetea la cámara para que no se vuelva loca al cambiar de posicion.
                ResetMainCamera();
            } 
        }
        else if(!hidden.imHidden && !imHere) up_DownHidden.enabled = false;
    }
    void ArrowUI()
    {
        Vector3 distanceDoors;
        distanceDoors = direction.position - transform.position;

        up_DownHidden.enabled = true;

        //Where do you want arrow aimed
        if (distanceDoors.y < 0) up_DownHidden.rectTransform.rotation = new Quaternion(0f, 0f, 180f,0f); 
        else if(distanceDoors.y > 0) up_DownHidden.rectTransform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
    void ResetMainCamera()
    {
        if(!resetCamera)
        {
            mainCamera.Follow = puertaTransporte;
            Debug.Log("Comienza Reseteo");
            resetCamera = true;
        }
    }
    void CameraDefault()
    {
        if (resetCamera)
        {
            timeWaitReset += Time.deltaTime;
            if(timeWaitReset >= 0.5f)
            {
                //Puede que haya que colocar un contador
                mainCamera.Follow = player;
                resetCamera = false;
                timeWaitReset = 0;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Escondite")) imHere = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Escondite")) imHere = false;
    }
}
