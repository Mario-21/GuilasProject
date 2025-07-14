using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class CogerReliquias : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string idReliquia;

    [ContextMenu("Generar ID Reliquia")]
    private void GenerateGuid()
    {
        idReliquia = System.Guid.NewGuid().ToString();
    } 

    public int numeroReliquia;
    bool estoyEnLaReliquia;
    bool reliquiaPillada;
    [Header("Sonido al coger la Reliquia")]
    [SerializeField] EventReference sonidoReliquia;
    //Esto no se tiene que guardar aquí, pero me sirve para hacer pruebas
    public void LoadData(GameData reliquiaData)
    {
        reliquiaData.reliquiasCollected.TryGetValue(idReliquia, out reliquiaPillada); //ListaReliquias.instancia.listaReliquiasTotal[numeroReliquia].reliquiaObtenida);
        if (reliquiaPillada)//(ListaReliquias.instancia.listaReliquiasTotal[numeroReliquia].reliquiaObtenida)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void SaveData (ref GameData reliquiaData)
    {
        //ahora que lo pienso, quizas es porque desaparece el objeto y no puede guardar al no estar en escena
        if (reliquiaData.reliquiasCollected.ContainsKey(idReliquia))
        {
            //Ahora ya se pueden ver las Keys
            reliquiaData.reliquiasCollected.Remove(idReliquia);
        }
        reliquiaData.reliquiasCollected.Add(idReliquia, reliquiaPillada);//ListaReliquias.instancia.listaReliquiasTotal[numeroReliquia].reliquiaObtenida);
    }

    private void Start()
    {
        if (ListaReliquias.instancia.listaReliquiasTotal[numeroReliquia].reliquiaObtenida)
        {
            this.gameObject.SetActive(false);
            reliquiaPillada = true;
        }
    }
    private void Update()
    {
        if (estoyEnLaReliquia) PickReliquia();
    }
    void PickReliquia()
    {
        if (Input.GetButtonDown("Take")) 
        {
            AudioManager.instancia.PlayOneShot(sonidoReliquia);
            ListaReliquias.instancia.listaReliquiasTotal[numeroReliquia].reliquiaObtenida = true;
            reliquiaPillada = true;
            this.gameObject.SetActive(false);
        }
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
