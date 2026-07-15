using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class CogerReliquias : MonoBehaviour
{
    [SerializeField] private string idReliquia;
    public int numeroReliquia;
    bool estoyEnLaReliquia;
    public bool reliquiaPillada;
    public bool reliquiaRecogida;
    [Header("Sonido al coger la Reliquia")]
    [SerializeField] EventReference sonidoReliquia;
    //Esto no se tiene que guardar aquí, pero me sirve para hacer pruebas
    BoxCollider2D boxCollider2DReliquia;
    SpriteRenderer reliquiaSprite;

    private void Start()
    {
        
        GameDataNoDestroy.instance.gameData.reliquiasCollected.TryGetValue(idReliquia, out ListaReliquias.instancia.listaReliquiasTotal[ListaReliquias.instancia.numReliquiaNivel].reliquiaObtenida);
        boxCollider2DReliquia = GetComponent<BoxCollider2D>();
        reliquiaSprite = GetComponent<SpriteRenderer>();

        if (ListaReliquias.instancia.listaReliquiasTotal[numeroReliquia].reliquiaObtenida)
        {
            reliquiaSprite.enabled = false;
            boxCollider2DReliquia.enabled = false;
        }
    }
    private void Update()
    {
        if (estoyEnLaReliquia) PickReliquia();
        /*if (reliquiaPillada) 
        {
            GuardarReliquia();
            reliquiaPillada = false;
        }*/
    }
    void PickReliquia()
    {
        if (Input.GetButtonDown("Take")) 
        {
            AudioManager.instancia.PlayOneShot(sonidoReliquia);
            ListaReliquias.instancia.listaReliquiasTotal[numeroReliquia].reliquiaObtenida = true;
            reliquiaPillada = true;

            //Colocar en Dictionary que has obtenido la reliquia sin guardarla
            GuardarReliquia();
            //Desaparecer Objeto
            reliquiaSprite.enabled = false;
            boxCollider2DReliquia.enabled = false;
        }
    }
    public void GuardarReliquia()
    {
        //Colocar en Dictionary que has obtenido la reliquia sin guardarla
        if (GameDataNoDestroy.instance.gameData.reliquiasCollected.ContainsKey(idReliquia))
        {
            GameDataNoDestroy.instance.gameData.reliquiasCollected.Remove(idReliquia);
            //GameDataNoDestroy.instance.gameData.nivelesComplete.Add(idReliquia, reliquiaRecogida);
        }
        GameDataNoDestroy.instance.gameData.reliquiasCollected.Add(idReliquia, ListaReliquias.instancia.listaReliquiasTotal[numeroReliquia].reliquiaObtenida);
        Debug.Log("Te has pasado el nivel " + idReliquia);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            estoyEnLaReliquia = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) estoyEnLaReliquia = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) estoyEnLaReliquia = false;
    }
}
