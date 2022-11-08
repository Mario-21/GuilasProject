using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AngryChef : MonoBehaviour
{
    [Header("Camera Data")]
    [SerializeField] CinemachineVirtualCamera mainCamera;

    [Header("Player Data")]
    [SerializeField] Transform player;

    bool angry;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AngryTalk();
    }
    void AngryTalk()
    {
        if (angry)
        {
            //Camara se dirige al player;
            mainCamera.Follow = player;
            mainCamera.m_Lens.OrthographicSize = 4;
            AnimationHud.detectar_echar.SetBool("Transicion", false);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            angry = true;
        }
    }
}
