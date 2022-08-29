using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffHolter : MonoBehaviour
{
    PlayerHere player;
    [Header("Holter Info")]
    public GameObject holterEffect;
    [SerializeField] SpriteRenderer botonHolter;
    public bool onHolter;

    [Header("Doctor Info")]
    [SerializeField] SoldadoNormal doctor;
    [SerializeField] Transform doctorOriginalPos;
    public bool enemyHere;
    public float timeOnHolterDoctor;
    private void Start()
    {
        player = GetComponent<PlayerHere>();
    }
    void Update()
    {
        if (player.playerImHere) ActiveHolter();
        OnHolter();
        OnHolterSoldier();
    }
    void ActiveHolter()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            onHolter = !onHolter;
        }
    }
    void OnHolter()
    {
        if (onHolter)
        {
            holterEffect.SetActive(true);
            botonHolter.color = Color.green;
        }
        else
        {
            holterEffect.SetActive(false);
            botonHolter.color = Color.red;
        }
    }
    void OnHolterSoldier()
    {
        if (!onHolter && enemyHere)
        {
            timeOnHolterDoctor += Time.deltaTime;
            if(timeOnHolterDoctor >= 4)
            {
                onHolter = true;
                doctor.ubicacionesDirigir[0] = doctorOriginalPos;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) enemyHere = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) enemyHere = false;
    }
}
