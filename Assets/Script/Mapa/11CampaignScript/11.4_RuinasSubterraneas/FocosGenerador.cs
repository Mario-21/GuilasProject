using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FocosGenerador : MonoBehaviour
{
    PlayerHere player;
    [Header("Generador Luces")]
    [SerializeField] List<GameObject> luces;
    [Header("Generador Feedback")]
    [SerializeField] SpriteRenderer boton;
    [Header("Time Enemy On Generator")]
    public float enemyTimeOnLimit;
    float enemyTimeOn;
    [Header("Enemy Use Generador")]
    [SerializeField] SoldierLife soldado;

    [HideInInspector] public bool focosOn;
    bool onEnemy;
    //Colocar que solo ocurrira mientras el soldado este vivo

    int indexLuces;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        focosOn = true;
    }
    void Update()
    {
        On_Off_Player();
        StatusLigth();
        On_Off_Enemy();
        BotonStatus();
    }
    void On_Off_Player()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                focosOn = !focosOn;
                indexLuces = 0;
            }
        }
    }
    void StatusLigth()
    {
        if (focosOn)
        {
            while (indexLuces < luces.Count)
            {
                luces[indexLuces].SetActive(true);
                indexLuces++;
                Debug.Log("El index de Luz es " + indexLuces);
            }
        }
        else
        {
            while (indexLuces < luces.Count)
            {
                luces[indexLuces].SetActive(false);
                indexLuces++;
                Debug.Log("El index de Luz es " + indexLuces);
            }
        }
    }
    void On_Off_Enemy()
    {
        if (onEnemy && soldado.vida > 0)
        {
            enemyTimeOn += Time.deltaTime;
            if(enemyTimeOn >= enemyTimeOnLimit)
            {
                focosOn = true;
                indexLuces = 0;
            }
        }
        else
        {
            enemyTimeOn = 0;
        }
    }
    void BotonStatus()
    {
        if (focosOn)
        {
            boton.color = Color.green;
        }
        else
        {
            boton.color = Color.red;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            onEnemy = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            onEnemy = false;
        }
    }
}
