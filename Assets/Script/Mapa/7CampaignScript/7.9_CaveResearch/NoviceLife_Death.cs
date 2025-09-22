using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoviceLife_Death : MonoBehaviour
{
    public int exceedTime;
    public int minusTime;
    [Header("Partes Cuerpo Novato")]
    [SerializeField] SpriteRenderer headNovice;
    [SerializeField] SpriteRenderer brazoNovice;
    [Header("Animaciones")]
    [SerializeField] Animator noviceCuerpo;
    [SerializeField] Animator noviceCabeza;
    [Header("Sprites Post-Morten")]
    public Sprite cabezaNoOxygen;
    public Sprite brazoNoOxygen;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[exceedTime].modificacion)
        {
            headNovice.sprite = cabezaNoOxygen;
            brazoNovice.sprite = brazoNoOxygen;
            noviceCuerpo.enabled = false;
            noviceCabeza.enabled = false;
        }
        /*else if (StatusGameobjectsVariables.statusGameobject.modificacion[minusTime].modificacion)
        {
            headNovice.color = Color.white;
         
        }*/
    }
}
