using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsOnShip : MonoBehaviour
{
    public int indexMod;
    [Header("Reposition Ubication")]
    public Transform ubiReposition;
    [Header("Items")]
    public GameObject itemDis;
    public GameObject itemAppear;
    [Header("Barco Data")]
    public Barco barca;
    public Rigidbody2D rb2DBarca;
    [Header("Player Ubication")]
    public Transform ubiPlayer;
    public BloquearMovimientoPlayer playerBloq;
    [Header("Tiempo Reposicionar")]
    public float timeRepositionLimit;
    float timeReposition;

    ActivarModificador activador;

    private void Awake()
    {
        activador = GetComponent<ActivarModificador>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activador.modificacion)
        {
            RepositionBarco();
        }
    }
    void RepositionBarco()
    {
        if(timeReposition < timeRepositionLimit)
        {
            //Comienza el tiempo en el que se desarollara la accion
            timeReposition += Time.deltaTime;
            //Bloquear mi movimiento
            playerBloq.BloquearMovPlayer();
            //Transicion a negro 
            AnimationHud.detectar_echar.SetBool("Transicion", true);
            //Desactiva la barca para que te quedes quieto
            barca.enabled = false;
            //Estableces la velocidad en cero para que no se te vaya la barca
            rb2DBarca.velocity = new Vector2(0,rb2DBarca.velocity.y);
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
        else
        {
            //Desactivas y activas los objetos usados dentro de la barca 
            itemDis.SetActive(false);
            itemAppear.SetActive(true);
            //Coloca al Player fuera del rango de la accion para que no se bugee
            ubiPlayer.position = ubiReposition.position;
            //Se aclara la pantalla otra vez
            AnimationHud.detectar_echar.SetBool("Transicion", false);
            //Puedes volverte a mover con el barco
            barca.enabled = true;
            //Se te establecen de nuevo todas las estádisticas
            playerBloq.HabilitarPlayerBarco();
            //Desactivas el script una vez acabado
            this.enabled = false;
        }
    }
}
