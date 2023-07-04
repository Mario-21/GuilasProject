using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoteroTime : MonoBehaviour
{
    public int indexMod;
    [Header("Time Coco Fall")]
    [SerializeField] float timeFallCoco;
    [SerializeField] float timeFallCocoLimit;
    [Header("Coco's Data")]
    [SerializeField] Rigidbody2D rb2dCoco;
    [SerializeField] GameObject cocoGround;
    [Header("Particulas Cocotero")]
    [SerializeField] ParticleSystem cocoteroParticle;
    [SerializeField] float timeRepeatAction;
    [SerializeField] float intervalo;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            rb2dCoco.GetComponent<GameObject>().SetActive(false);
            cocoGround.SetActive(true);
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RepeatAction();
        if(timeFallCoco >= timeFallCocoLimit)
        {
            rb2dCoco.bodyType = RigidbodyType2D.Dynamic;
            cocoGround.SetActive(true);
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            this.enabled = false;
        }
        else
        {
            timeFallCoco += Time.deltaTime;
        }
    }
    void RepeatAction()
    {
        if(timeFallCoco >= timeRepeatAction)
        {
            timeRepeatAction += intervalo;
            cocoteroParticle.Play();
        }
    }
}

