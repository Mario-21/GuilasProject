using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDeepLife : MonoBehaviour
{
    public int indexSoldado;
    public int vida;

    SoldadoProfundo soldado;

    void Start()
    {
        soldado = GetComponent<SoldadoProfundo>();
        //Carga la vida tras volver a escena
        LoadStatus();
    }
    void Update()
    {
        DeathAnim();
    }
    private void OnDestroy()
    {
        //Guarda La vida tras cambiar de escena
        SaveStatus();
    }
    public void Daño(int daño)
    {
        vida -= daño;
    }
    void DeathAnim()
    {
        if(vida <= 0)
        {
            //Animacion muerte;
            soldado.enabled = false;
            this.enabled = false;
        }
    }
    void SaveStatus()
    {
        SoldierActiveInScene.instancia.soldiersStatus[indexSoldado].statusVida = vida;
    }
    void LoadStatus()
    {
        vida = SoldierActiveInScene.instancia.soldiersStatus[indexSoldado].statusVida;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BalaPlayer") ||
           collision.gameObject.CompareTag("B8") || 
           collision.gameObject.CompareTag("ObjetoCaer"))
        {
            Debug.Log("GOETiA");
            Destroy(collision.gameObject);
            Daño(1);
        }
    }

}
