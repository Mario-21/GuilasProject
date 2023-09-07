using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GiveItemEnemy : MonoBehaviour
{
    bool onGive;

    float timeGiveItem;

    public GameObject notaSoldado;
    public GameObject notaGive;

    [SerializeField] SoldadoNormal soldadoCodigo;

    enum CinGiveitem
    {
        Start,
        GiveItem,
        End
    }
    CinGiveitem giveEnemy;

    [Header("Give SFX")]
    [SerializeField] EventReference giveTrade_SFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CinGive();
    }
    void CinGive()
    {
        if (onGive)
        {
            switch (giveEnemy)
            {
                case CinGiveitem.Start:
                    //Te acercas y se hace la transicion a negro para simular que le das el Item
                    timeGiveItem += Time.deltaTime;
                    if (timeGiveItem >= 2)
                    {
                        AnimationHud.detectar_echar.SetBool("Transicion", true);
                        timeGiveItem = 0;
                        giveEnemy = CinGiveitem.GiveItem;
                    }
                    break;
                case CinGiveitem.GiveItem:
                    timeGiveItem += Time.deltaTime;
                    if (timeGiveItem >= 2)
                    {
                        GiveItem();
                        AnimationHud.detectar_echar.SetBool("Transicion", false);
                        timeGiveItem = 0;
                        giveEnemy = CinGiveitem.End;
                    }
                    break;
                case CinGiveitem.End:
                    timeGiveItem += Time.deltaTime;
                    if (timeGiveItem >= 3)
                    {
                        soldadoCodigo.enabled = true;
                    }
                    break;
            }
        }
    }
    void GiveItem()
    {
        AudioManager.instancia.PlayOneShot(giveTrade_SFX);
        notaSoldado.SetActive(false);
        notaGive.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            onGive = true;
        }
    }
}
