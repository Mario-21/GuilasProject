using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FinishIntro : MonoBehaviour
{
    public int indexMod;
    [Header("Player Data Scene")]
    [SerializeField] BloquearMovimientoPlayer playerBloq;
    [SerializeField] Transform player;
    [Header("Camera")]
    public CinemachineVirtualCamera mainCamera;
    [Header("Novato Data Scene")]
    [SerializeField] SoldadoNormal novice;
    [Header("First Part Intro")]
    [SerializeField] IntroCinematic introCinematic;

    enum FinIntro
    {
        First,
        Second,
        Third
    }
    FinIntro endIntro;
    bool end;
    float timeToFinish;
    void Start()
    {
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            novice.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        EndIntro();
    }
    void EndIntro()
    {
        if (end) 
        {
            if (timeToFinish >= 3)
            {
                mainCamera.Follow = player;
                AnimationHud.detectar_echar.SetBool("Transicion", false);
                playerBloq.HabilitarMovPlayer();
                novice.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                //introCinematic.enabled = false;
            }
            else timeToFinish += Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            AnimationHud.detectar_echar.SetBool("Transicion", true);
            end = true;
        }
        
    }
}
