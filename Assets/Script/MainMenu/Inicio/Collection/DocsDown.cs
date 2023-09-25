using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DocsDown : MonoBehaviour
{
    RectTransform myPos;
    public RectTransform posNext;
    public float velocidad;
    [Header("Flechas y Canvas")]
    public GameObject flechaIzq;
    public GameObject flechaDrcha;
    public CanvasGroup docCanvas;
    [Header("Luz")]
    public GameObject luzFake;

    bool killerMove;
    int soundLamp;
    void Start()
    {
        myPos = GetComponent<RectTransform>();
        killerMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Mi next Position no implica que sea siempre el mismo puede variar;
        if (killerMove)
        {
            docCanvas.alpha = 0;
            flechaDrcha.SetActive(false);
            flechaIzq.SetActive(false);
            if(myPos.position.y > posNext.position.y)
            {
                myPos.position = Vector2.MoveTowards(myPos.position, posNext.position, velocidad* Time.deltaTime);
            }
            else
            {
                //Sonido encendido
                luzFake.SetActive(true);
                if(soundLamp < 1)
                {
                    AudioManager.instancia.PlayOneShot(FMODEvent.instancia.lamp_UI);
                    soundLamp++;
                }
                killerMove = false;
            }
        }
    }
}
