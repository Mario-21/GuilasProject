using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barco : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Player Data")]
    [SerializeField] Transform player;
    [SerializeField] JugadorMovimiento playerMov;
    [Header("Datos Barco")]
    public float velocidad;
    public float horizontalMov;
    [SerializeField] float aceleracion;
    [SerializeField] float speed;
    [Header("Weapons and Conditions")]
    [SerializeField] ChangeWeapon conditionWeapon;
    [SerializeField] B8Arma b8;
    [SerializeField] ArmaController pistol;
    [Header("Switch Pala and Weapon")]
    [SerializeField] GameObject pala;
    [SerializeField] SpriteRenderer pistolSprite;
    [SerializeField] SpriteRenderer b8Sprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //El problema es la mira, al horientarse se coloca en base a la escala de Mira
        playerMov.CambiarDireccionDisparo();

        if (!pistol.activarDisparo && !b8.activarB8) 
        {
            horizontalMov = GetInput().x;
        }
        else
        {
            horizontalMov = 0;
        }
        MoveBarco();
    }
    void MoveBarco()
    {
        rb.AddForce(new Vector2(horizontalMov, 0f) * aceleracion);
        if (Mathf.Abs(rb.velocity.x) > speed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * velocidad, rb.velocity.y);
        }

        HorientacionBarco();
    }
    void HorientacionBarco()
    {
        //Escala del Personaje, cuando no apuntas con el arma

        //si tienes la pistola, cambiara entre la psitola y la pala
        if (!conditionWeapon.changeWeapon)
        {
            if (!pistol.activarDisparo)
            {
                pistolSprite.enabled = false;
                pala.SetActive(true);
                if (horizontalMov == 1) 
                {
                    //Orientacion barco
                    transform.localScale = new Vector3(1, 1, 1);
                    //El Player se orienta en base al barco
                    player.transform.localScale = new Vector3(1, 1, 1);
                }
                if (horizontalMov == -1) 
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    player.transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                pistolSprite.enabled = true;
                pala.SetActive(false);
            }
        }
        //si tienes la B8, cambiara entre la B8 y la pala
        else
        {
            if (!b8.activarB8)
            {
                pala.SetActive(true);
                b8Sprite.enabled = false;
                Debug.Log("Wepon 8V");
                if (horizontalMov == 1) 
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    player.transform.localScale = new Vector3(1, 1, 1);
                }
                if (horizontalMov == -1) 
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    player.transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                pala.SetActive(false);
                b8Sprite.enabled = true;
            }
        }
    }
    Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
