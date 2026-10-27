using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FMODUnity;

public class AngryChef : MonoBehaviour
{
    public int indexMod;

    [Header("Camera Data")]
    [SerializeField] CinemachineVirtualCamera mainCamera;
    [SerializeField] float orthographicSize;

    [Header("Player Data")]
    [SerializeField] Transform player;

    [Header("Dialogo Data")]
    [SerializeField] GameObject globoDialogo;
    [SerializeField] Transform ubiDialogo;
    GameObject copiaGloboDialogo;

    [Header("Duration Scene")]
    public float timeDialogoLimit;
    public float timeEndLimit;
    float timeScene;
    [SerializeField] UseCin endScene;

    bool angry;
    int once;

    enum Secuencia
    {
        Dialogo,
        End
    }
    Secuencia scena;
    [Header("SFX Dialogue")]
    [SerializeField] EventReference soundDialogue;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
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
            mainCamera.m_Lens.OrthographicSize = orthographicSize;
            AnimationHud.detectar_echar.SetBool("Transicion", false);

            switch (scena)
            {
                case Secuencia.Dialogo:
                    {
                        if (timeScene >= timeDialogoLimit)
                        {
                            if (once < 1)
                            {
                                copiaGloboDialogo = Instantiate(globoDialogo, ubiDialogo.position, Quaternion.identity);
                                copiaGloboDialogo.transform.parent = ubiDialogo;
                                AudioManager.instancia.PlayOneShot(soundDialogue); 
                                timeScene = 0;
                                scena = Secuencia.End;
                            }
                        }
                        else
                        {
                            timeScene += Time.deltaTime;
                        }
                    }
                    break;
                case Secuencia.End:
                    if (timeScene >= timeEndLimit)
                    {
                        endScene.UseCinematic();
                        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                    }
                    else
                    {
                        timeScene += Time.deltaTime;
                    }
                    break;
            }

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
