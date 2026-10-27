using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextNoItem : MonoBehaviour
{
    public int indexMod;
    public string itemTag;
    [Header("Texto")]
    [SerializeField] CanvasGroup text;
    [Header("Condiciones See Text")]
    [SerializeField] SoldierLife soldierVida;
    [Header("Item")]
    [SerializeField] ActivarModificador activador;
    [Header("Time Text")]
    public float timeTextLimit;
    float timeText;

    bool showMeText;
    //Item info
    public bool withItem;
    bool youCanChange;
    bool playerIsInRange;

    CogerObjeto pickItem;

    void Start()
    {
        if (!withItem)
        {
            pickItem = GetComponent<CogerObjeto>();
        }
        
    }
    void Update()
    {
        //Al mostrar el texto desaparecera con el tiempo
        DisAppearText();

        if (withItem)
        {
            //Muestra Texto
            MostrarTextoItem();
            //Condiciones para no ver el Texto
            NoMostrarTextUseItem();
        }
        else
        {
            MostrarTexto();

        }
    }

    void MostrarTextoItem()
    {
        if(soldierVida.vida > 0)
        {
            if (youCanChange && playerIsInRange && Input.GetButtonDown("Fire1"))
            {
                text.alpha = 1;
                timeText = 0;
                showMeText = true;
            }
        }

    }
    void DisAppearText()
    {
        if (showMeText)
        {
            timeText += Time.deltaTime;
            if (timeText >= timeTextLimit)
            {
                showMeText = false;
            }
        }
        else
        {
            text.alpha -= 0.01f;
        }
    }
    void NoMostrarTextUseItem()
    {
        //Si el soldado ha muerto o la variable  se ha activado, Ya no muestres el texto y desactiva su activador
        if(soldierVida.vida < 1 || StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            //El habilitar poder usar el item
            activador.enabled = true;
            //Desactivar texto
            this.enabled = false;
            text.alpha = 0;
            showMeText = false;
        }
    }
    void MostrarTexto()
    {
        if (soldierVida.vida > 0)
        {
            if (playerIsInRange && Input.GetKeyDown(KeyCode.T))
            {
                text.alpha = 1;
                timeText = 0;
                showMeText = true;
            }
        }
        else
        {
            pickItem.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(itemTag)) youCanChange = true;
        if (collision.gameObject.CompareTag("Player")) playerIsInRange = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(itemTag)) youCanChange = true;
        if (collision.gameObject.CompareTag("Player")) playerIsInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(itemTag)) youCanChange = false;
        if (collision.gameObject.CompareTag("Player")) playerIsInRange = false;
    }

}
