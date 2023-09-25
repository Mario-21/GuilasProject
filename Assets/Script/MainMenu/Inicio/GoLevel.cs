using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GoLevel : MonoBehaviour
{
    SpriteRenderer sprite;
    public int goScene;
    [Header("Transicion Animacion")]
    public string nameAnimVar;
    public Animator transtion;
    [Header("SFX")]
    [SerializeField] EventReference sfx;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnMouseEnter()
    {
        AudioManager.instancia.PlayOneShot(sfx);
        sprite.color = Color.green;
        Debug.Log("Mouse Entro");
    }
    private void OnMouseExit()
    {
        sprite.color = Color.red;
        Debug.Log("Mouse Exit");
    }
    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Mouse Fire");
            Calls_Transition calls = new Calls_Transition();
            calls.Call(transtion, nameAnimVar);
            //Desactivar colliders para que no se pueda volver a presionar el bton
            OutMenuButtons.colliderButtonsStatus = false;
            sprite.color = Color.yellow;
            EstructuraNiveles.nivel = goScene;
        }
    }
}
