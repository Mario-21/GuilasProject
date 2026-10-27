using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class CuboLamentos : MonoBehaviour
{
    public int indexMod;
    [Header("Password")]
    public string password;
    [Header("Cubo")]
    [SerializeField] Image cuboLamentos;
    [SerializeField] Image[] botones;
    [HideInInspector] public string passwordComplete;
    public GameObject reliquia;
    [Header("Icon Player")]
    public GameObject iconPlayer;
    public SpriteRenderer iconSpritePlayer;
    public Sprite icon;
    [Header("SFX Cubo")]
    [SerializeField] EventReference sfx_OpenCubo;

    PlayerHere player;
    [HideInInspector] public bool inCubo;

    bool onIcon;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            reliquia.SetActive(true);
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //PassWord
        ClearPassword();
        CompletePassword();
        //Activar el cubo
        UseCube();
        //Ver Icono
        IconSee();
    }

    void ClearPassword()
    {
        if (!inCubo)
        {
            passwordComplete = "";
        }
    }
    void CompletePassword()
    {
        if(password == passwordComplete)
        {
            AudioManager.instancia.PlayOneShot(sfx_OpenCubo);
            //Aparece Reliquia
            reliquia.SetActive(true);
            //Interfaz del cubo se va fuera
            OffCubo();
            //Activa el modificador
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            //Desactivas el cubo y el icono
            this.enabled = false;
            onIcon = false;
        }
        else
        {
            SeeCube();
        }
    }
    void UseCube()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                inCubo = !inCubo;
                if (inCubo)
                {
                    iconPlayer.SetActive(false);
                }
                else
                {
                    iconPlayer.SetActive(true);
                }
            }
        }
        else
        {
            
            inCubo = false;
        }
    }
    void SeeCube()
    {
        if (inCubo)
        {
            cuboLamentos.enabled = true;
            foreach (Image boton in botones)
            {
                boton.enabled = true;
            }
        }
        else
        {
            OffCubo();
        }

    }
    void OffCubo()
    {
        cuboLamentos.enabled = false;
        foreach (Image boton in botones)
        {
            boton.enabled = false;
        }
    }
    void IconSee()
    {
        if (onIcon)
        {
            iconPlayer.SetActive(true);
            iconSpritePlayer.sprite = icon;
        }
        else
        {
            iconPlayer.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Script aparte para que aparezcan los iconos
        if (collision.gameObject.CompareTag("Player"))
        {
            onIcon = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inCubo = false;
            onIcon = false;
        }
    }
    
}
