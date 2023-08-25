using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CogerItemUI : MonoBehaviour
{
    public int indexUIMod;
    PlayerHere player;
    public GameObject itemUI;

    [Header("Sound Effect")]
    [SerializeField] EventReference takeSound;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if(ListaItemsUI.listaItemsUI.listaAllItemUI[indexUIMod].itemUICatch) this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerImHere) PickItemUI();
    }
    void PickItemUI()
    {
        if (Input.GetButtonDown("Take"))
        {
            AudioManager.instancia.PlayOneShot(takeSound);
            itemUI.SetActive(true);
            ListaItemsUI.listaItemsUI.listaAllItemUI[indexUIMod].itemUICatch = true;
            this.gameObject.SetActive(false);
        }
    }
}
