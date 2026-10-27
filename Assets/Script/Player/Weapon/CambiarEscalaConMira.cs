using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarEscalaConMira : MonoBehaviour
{
    public Transform miraVersion2;
    public Transform centroDelPersonaje;
    Vector2 calculo;
    float calculoX;
    public GameObject player;
    [Header("Armas")]
    [SerializeField] B8Arma b8Arma;
    [SerializeField] ArmaController arma;
    void Start()
    {
        
    }

    void Update()
    {
        if(b8Arma.activarB8 || arma.activarDisparo)
        {
            calculo = new Vector2(miraVersion2.position.x - centroDelPersonaje.position.x, miraVersion2.position.y - centroDelPersonaje.position.y);
            if (calculo.x < 0)
            {
                player.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (calculo.x > 0)
            {
                player.transform.localScale = new Vector3(1, 1, 1);
            }
            calculoX = calculo.x;
        }
    }
}
