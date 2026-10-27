using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ColocarReliquiaUI : MonoBehaviour
{
    public int indexUI;
    public int indexMod;
    [Header("Item Data")]
    public GameObject item;
    public GameObject itemUI;
    [Header("Sfx")]
    [SerializeField] EventReference sfx;

    PlayerHere player;

    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.gameObject.SetActive(false);
            item.SetActive(true);
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Si tienes el objeto y estas cerca de la posicion puedes colocar el objeto
        if (ListaItemsUI.listaItemsUI.listaAllItemUI[indexUI].itemUICatch && player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(sfx);
                item.SetActive(true);
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                this.gameObject.SetActive(false);
                //Quitar el UI de la lista, ya que lo acabas de usar 
                ListaItemsUI.listaItemsUI.listaAllItemUI[indexUI].itemUICatch = false;
                itemUI.SetActive(false);
                this.enabled = false;


            }
        }
    }
}
