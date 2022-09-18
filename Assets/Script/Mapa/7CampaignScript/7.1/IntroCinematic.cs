using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class IntroCinematic : MonoBehaviour
{
    public int indexMod;
    [Header("Player Data Scene")]
    [SerializeField] BloquearMovimientoPlayer playerBloqIntro;
    [Header("Camera")]
    public CinemachineVirtualCamera mainCamera;
    [Header("Novato Data Scene")]
    [SerializeField] SoldadoNormal noviceIntro;
    [SerializeField] GameObject bocadillo;
    [Header("Ascensor Minero")]
    [SerializeField] AscensorMinero ascensorIntro;
    enum IntroBegin
    {
        Firts,
        Second,
        Third,
        End
    }

    IntroBegin startScene;
    float timeBetweenScene;
    bool introStart;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            noviceIntro.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            bocadillo.SetActive(false);
        }
    }
    void Update()
    {
        if (introStart && playerBloqIntro.player.onGround) Intro();
    }
    void Intro()
    {
        switch (startScene)
        {
            case IntroBegin.Firts:
                //Para al Player
                playerBloqIntro.BloquearMovPlayer();
                AnimationHud.detectar_echar.SetBool("Transicion", true);
                if(timeBetweenScene >= 3)
                {
                    mainCamera.Follow = noviceIntro.transform;
                    startScene = IntroBegin.Second;
                }
                else
                {
                    timeBetweenScene += Time.deltaTime;
                }
                break;
            case IntroBegin.Second:
                //El soldado se dirige a la plataforma
                AnimationHud.detectar_echar.SetBool("Transicion", false);
                if(timeBetweenScene <= 0)
                {
                    noviceIntro.enabled = true;
                    bocadillo.SetActive(false);
                    startScene = IntroBegin.Third;
                }
                else
                {
                    timeBetweenScene -= Time.deltaTime;
                }
                break;
            case IntroBegin.Third:
                //El soldado va y enciende el ascensor
                if(timeBetweenScene >= 5)
                {
                    ascensorIntro.interruptorBajar = false;
                    startScene = IntroBegin.End;
                }
                else
                {
                    timeBetweenScene += Time.deltaTime;
                }
                break;
            case IntroBegin.End:
                this.gameObject.SetActive(false);
                Debug.Log("First Part Done");
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            introStart = true;
        }
    }
}
