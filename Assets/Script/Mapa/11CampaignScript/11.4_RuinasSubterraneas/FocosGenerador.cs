using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocosGenerador : MonoBehaviour
{
    PlayerHere player;

    [SerializeField] List<GameObject> luces;

    [Header("Time Enemy On Generator")]
    public float enemyTimeOnLimit;
    float enemyTimeOn;

    [HideInInspector] public bool focosOn;
    bool onEnemy;

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
        if (onEnemy)
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
