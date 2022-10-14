using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuboLamentos : MonoBehaviour
{
    [Header("Password")]
    public string password;
    [SerializeField] GameObject cuboLamentos;
    [HideInInspector] public string passwordComplete;
    [Header("Icon Player")]
    public GameObject iconPlayer;
    public SpriteRenderer iconSpritePlayer;
    public Sprite icon;

    PlayerHere player;
    [HideInInspector] public bool inCubo;
    void Start()
    {
        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        ClearPassword();
        CompletePassword();
        //Activar el cubo
        UseCube();
        //Ver el cubo
        SeeCube();
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
            this.enabled = false;
            //IndexCubo
            //ActivarCinematica
            //
        }
    }
    void UseCube()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
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
            cuboLamentos.SetActive(true);
        }
        else
        {
            cuboLamentos.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Script aparte para que aparezcan los iconos
        if (collision.gameObject.CompareTag("Player"))
        {
            iconPlayer.SetActive(true);
            iconSpritePlayer.sprite = icon;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            iconPlayer.SetActive(false);
        }
    }
    
}
