using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoUseItem : MonoBehaviour
{
    public int indexMod;
    [Header("Condiciones See Text")]
    [SerializeField] List<SoldierLife> soldierVida;
    public int soldadoDeath;
    bool soldadoSeeYou;
    [Header("Texto")]
    [SerializeField] CanvasGroup text;
    [Header("Time Text")]
    public float timeTextLimit;
    float timeText;
    [Header("Item Use")]
    public string tagItem;
    bool itemTrigger;
    [Header("Trigger Can Use Item")]
    public GameObject triggerUseDinamita;

    PlayerHere player;
    bool showText;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;   
        }
    }

    // Update is called once per frame
    void Update()
    {
        FinishText();
        MostrarText();
        OutText();
        SoldadosAsignados();
    }
    void MostrarText()
    {
        if(player.playerImHere && itemTrigger)
        {
            if (Input.GetButtonDown("Fire1") && soldadoSeeYou)
            {
                //Debe mirar si los soldados esta vivos, si lo estan muestra el texto si, si estan muertos simplemente desactiva este script y activa el trigger que realmente detecta la dinamita
                //Los personajes muertos debe detectarlos aparte
                //Quiza hacerlo en dos script aparte para que no este constantemente haciendo el bucle
                showText = true;
                text.alpha = 1;
                timeText = 0;
            }
        }

    }
    void OutText()
    {
        if (showText)
        {
            timeText += Time.deltaTime;
            if (timeText >= timeTextLimit)
            {
                showText = false;
            }
        }
        else
        {
            text.alpha -= 0.01f;
        }
    }
    void SoldadosAsignados()
    {
        if(soldadoDeath < soldierVida.Count)
        {
            for (int i = 0; i < soldierVida.Count; i++)
            {
                if (soldierVida[i].vida > 0)
                {
                    //mostrar texto
                    soldadoSeeYou = true;
                    Debug.Log("Soy Soldado " + soldierVida[i].name);
                }
                else
                {
                    soldierVida.Remove(soldierVida[i]);
                    soldadoDeath++;
                }
            }
        }
    }
    void FinishText()
    {
        if (soldadoDeath >= soldierVida.Count)
        {
            soldadoSeeYou = false;
            triggerUseDinamita.SetActive(true);
            this.enabled = false;
            text.alpha = 0;
            timeText = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagItem)) itemTrigger = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagItem)) itemTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagItem)) itemTrigger = false;
    }

}
