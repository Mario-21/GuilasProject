using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class ActivarModificador : MonoBehaviour
{
    public string tagName;
    public bool modificacion;
    bool youCanChange;
    bool playerIsInRange;

    public SaveButton buttonOfItemUse;

    [Header("Tipo de Sonido")]
    public EventReference sonidoAction;
    [HideInInspector] public StudioEventEmitter emissorAction;
    public enum TypeSound
    {
        PlayOneShot,
        Emitter,
        Default
            //Nota: Para el emitter necesitare un script aparte que lo inicie, debido a que si sales de la escena no volvera a reproducirse.
    }
    public TypeSound tipoSonido;

    //emitterSteps = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.stepsEnemy, this.gameObject);
    private void Start()
    {
        switch (tipoSonido)
        {
            case TypeSound.PlayOneShot:
                Debug.Log("Soy PlayOneShot y no tengo que asignar nada");
                break;
            case TypeSound.Emitter:
                emissorAction = AudioManager.instancia.InitializeEventEmitter(sonidoAction, this.gameObject);
                break;
        }
    }
    void Update()
    {
        //Si el player esta cerca del objeto y ha sacado el objeto
        if (youCanChange && playerIsInRange)
        {
            Debug.Log("Preparado para la ACCION");
            //Usas el objeto
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("ACCION on");
                UsarObjeto();
                SoundOfAction();
            }
            
        }
    }

    void UsarObjeto()
    {

        //Si usas el objeto
        modificacion = true;
        //Increase the number of uses from object 
        SaveScene.instancia.listaItemsNivelGuardar[buttonOfItemUse.indexButton].vecesUsadoObjeto++;
        //If the object its equal to the max uses, this button becomes inactive
        buttonOfItemUse.LimitarUsos();
    }
    void SoundOfAction()
    {
        switch (tipoSonido)
        {
            case TypeSound.PlayOneShot:
                AudioManager.instancia.PlayOneShot(sonidoAction);
                break;
            case TypeSound.Emitter:
                emissorAction.Play();
                Debug.Log("Emision");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName)) youCanChange = true;
        if (collision.gameObject.CompareTag("Player")) playerIsInRange = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName)) youCanChange = true;
        if (collision.gameObject.CompareTag("Player")) playerIsInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName)) youCanChange = false;
        if (collision.gameObject.CompareTag("Player")) playerIsInRange = false;
    }
    
}
