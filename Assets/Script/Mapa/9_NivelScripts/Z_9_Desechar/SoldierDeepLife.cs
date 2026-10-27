using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDeepLife : MonoBehaviour
{
    public int indexSoldado;
    public int vida;
    [SerializeField] SpriteRenderer deathProvisional;
    [SerializeField] Sprite deathSprite;
    SoldadoProfundo soldado;
    int saveOne;

    void Start()
    {
        saveOne = vida;
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
        SavePos();
    }
    public void Daño(int daño)
    {
        vida -= daño;
        SaveVida();
    }
    void DeathAnim()
    {
        if(vida <= 0)
        {
            //Animacion muerte;
            deathProvisional.color = Color.red;
            soldado.enabled = false;
            this.enabled = false;
        }
    }
    void SaveVida()
    {
        if(saveOne != vida)
        {
            SoldierActiveInScene.instancia.soldiersStatus[indexSoldado].statusVida = vida;
            saveOne = vida;
        }
    }
    void SavePos()
    {
        SoldierActiveInScene.instancia.soldiersStatus[indexSoldado].position_x = transform.position.x;
        SoldierActiveInScene.instancia.soldiersStatus[indexSoldado].position_y = transform.position.y;
    }
    void LoadStatus()
    {
        vida = SoldierActiveInScene.instancia.soldiersStatus[indexSoldado].statusVida;
        //Este enemigo solo puede morir de frente.
        if (vida <= 0)
        {
            //Recoloca la escala a 1 porque al morir de frente se tiene que quedar lo mas proximo a la pantalla, por el efecto optico de de la zona de tiro. Aunque es una aproximacion
            transform.localScale = new Vector3(1, 1, 1);

            //Si siempre tienes que morir de frente el sprite tiene que estar de frente
            deathProvisional.sprite = deathSprite;

            //Ultima ubicacion
            Vector3 lastPosition;
            lastPosition = new Vector3(SoldierActiveInScene.instancia.soldiersStatus[indexSoldado].position_x, SoldierActiveInScene.instancia.soldiersStatus[indexSoldado].position_y, 0f);

            transform.position = lastPosition;
        }
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
